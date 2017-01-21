using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Media.Effects;
using System.Windows.Media.Animation;

namespace MemoDic {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		string ID, PW = "";
		int loginIndex;
		bool PWEditableFlag = true;
		bool loginFlag = false;
		bool registerFlag = false;
		bool changePWFlag = false;
		string[] newUserInfo = null;
		List<string[]> configInfo = new List<string[]>();
		List<string[]> logInfo = new List<string[]>();
		List<string[]> userInfo = new List<string[]>();

		public MainWindow() {
			InitializeComponent();
			try {
				// 프로그램 시작 시 정보 로딩
				configInfo = LoadFile("config.dat", 0);
				userInfo = LoadFile("user.dat", 5);
				logInfo = LoadFile("log.dat", 10);
				if (configInfo[0][1] == "True" || configInfo[0][1] == "true") {
					CHB_Remember_me.IsChecked = true;
					try {
						TB_ID.Text = logInfo[0][0];
						TB_PW.Text = logInfo[0][1];
					}
					catch { };
				}
			}
			catch (Exception exc) {
				TB_Message.Text = exc.ToString();
			};
		}

		protected override void OnClosed(EventArgs e) {
			// 프로그램 종료 시 정보 저장
			SaveFile("config.dat", configInfo, 0);
			SaveFile("user.dat", userInfo, -5);
			SaveFile("log.dat", logInfo, -10);
		}

		private void BTT_Login_Click(object sender, RoutedEventArgs e) {
			try {
				// 로그아웃
				if (loginFlag) {
					// 계정 삭제 완료 시
					string[] find = userInfo[loginIndex];
					if (registerFlag) {
						if(PW == find[1]) {
							TB_Message.Text = "Successfully deleted! (ID: " + find[0] + ")";
							userInfo.Remove(find);
							TB_PW.Text = "";
							registerFlag = false;
							TB_Register.Text = "Register";
						}
						else {
							TB_Message.Text = "The PW is not correct.";
							return;
						}
					}
					else if(changePWFlag) {
						TB_Message.Text = "You are changing PW. It must be finished or canceled first.";
						return;
					}
					else TB_Message.Text = "Successfully logged out.";

					// 로그인 가능 상태로 초기화
					TB_ID.Text = "";
					TB_ID.IsEnabled = true;
					BTT_Login.Content = "Login";
					loginFlag = false;
					CHB_Remember_me.IsEnabled = true;
					CHB_Remember_me.IsChecked = false;
					configInfo[0][1] = "False";
					TB_Register.Text = "Register";
					TB_FindID.Text = "Find ID";
					return;
				}

				// 로그인
				ID = TB_ID.Text;
				loginIndex = userInfo.FindIndex(delegate (string[] x) {
					return (x[0] == ID);
				});
				if (loginIndex == -1) TB_Message.Text = "No matching ID found.";
				else if (userInfo[loginIndex][1] != PW) TB_Message.Text = "The PW is not correct.";
				else {
					// 계정 정보 기억
					if (CHB_Remember_me.IsChecked == true) {
						configInfo[0][1] = "True";
						if (logInfo.Count == 0) logInfo.Add(new string[] { ID, PW });
						else {
							logInfo[0][0] = ID;
							logInfo[0][1] = PW;
						}
					}
					else configInfo[0][1] = "False";

					// 로그인 상태로 전환
					TB_ID.IsEnabled = false;
					TB_PW.Text = "";
					BTT_Login.Content = "Logout";
					loginFlag = true;
					CHB_Remember_me.IsEnabled = false;
					TB_Register.Text = "Delete ID";
					TB_FindID.Text = "Change PW";

					// 계정 등록 완료 시
					if (registerFlag && ID == newUserInfo[0]) {
						loginIndex = userInfo.Count;
						userInfo.Add(newUserInfo);
						newUserInfo = null;
						registerFlag = false;
						TB_Message.Text = "Successfully registered!";
					}
					else TB_Message.Text = "Successfully logged in.";
				}
			}
			catch (Exception exc) {
				TB_Message.Text = exc.ToString();
			};
		}
		
		private void TB_Register_MouseEnter(object sender, MouseEventArgs e) {
			TB_Register.TextDecorations = TextDecorations.Underline;
		}

		private void TB_Register_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
			// ID 및 PW 매칭 검사
			ID = TB_ID.Text;
			string[] find = userInfo.Find(delegate (string[] x) {
				return (x[0] == ID);
			});

			// 계정 삭제 또는 등록 취소 시
			if (registerFlag) {
				if (loginFlag) {
					TB_Register.Text = "Delete ID";
					TB_Message.Text = "The deletion of ID: " + ID + " was canceled.";
				}
				else {
					newUserInfo = null;
					TB_Register.Text = "Register";
					TB_Message.Text = "The registration of ID: " + newUserInfo[0] + " was canceled.";
				}
				registerFlag = false;
				return;
			}

			// PW 변경 계속 시
			if (changePWFlag) {
				if(newUserInfo == null) {
					if (PW.Length == 0) TB_Message.Text = "Input your new PW and click 'Continue'.";
					else if (PW.Length < 4) TB_Message.Text = "PW must have at least 4 digits.";
					else {
						newUserInfo = new string[] { ID, PW };
						TB_PW.Text = "";
						TB_Register.Text = "Finish";
						TB_Register_PreviewMouseLeftButtonDown(sender, e);
					}
				}
				else {
					if (PW.Length == 0) TB_Message.Text = "Input your new PW once more and click 'Finish'.";
					else if (PW != newUserInfo[1]) TB_Message.Text = "The PW is not correct.";
					else {
						newUserInfo = null;
						userInfo[loginIndex][1] = PW;
						TB_PW.Text = "";
						TB_Register.Text = "Delete ID";
						TB_FindID.Text = "Change PW";
						changePWFlag = false;
						TB_Message.Text = "Successfully been changed!";
					}
				}
				return;
			}

			// 계정 삭제
			if (loginFlag) {
				TB_PW.Text = "";
				TB_Register.Text = "Cancel";
				registerFlag = true;
				TB_Message.Text = "Log out with your PW to confirm the permanent deletion of your ID.";
				return;
			}

			// 계정 등록
			if (ID == "") TB_Message.Text = "Input your new ID and PW first.";
			else if (find != null) TB_Message.Text = "The ID already exists. Try other one.";
			else if (PW.Length < 4) TB_Message.Text = "PW must have at least 4 digits.";
			else {
				newUserInfo = new string[] { ID, PW };
				TB_PW.Text = "";
				TB_Register.Text = "Cancel";
				registerFlag = true;
				TB_Message.Text = "Log in with the new ID and PW to finish your registration.";
			}
		}

		private void TB_Register_MouseLeave(object sender, MouseEventArgs e) {
			TB_Register.TextDecorations = null;
		}

		private void TB_FindID_MouseEnter(object sender, MouseEventArgs e) {
			TB_FindID.TextDecorations = TextDecorations.Underline;
		}

		private void TB_FindID_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
			// PW 변경
			if (loginFlag) {
				// PW 변경 취소
				if (changePWFlag) {
					newUserInfo = null;
					TB_PW.Text = "";
					TB_Register.Text = "Delete ID";
					TB_FindID.Text = "Change PW";
					changePWFlag = false;
					TB_Message.Text = "Changing PW was canceled.";
					return;
				}

				if (registerFlag) TB_Message.Text = "You are deleting your ID. It must be finished or canceled first.";
				else if (PW.Length == 0) TB_Message.Text = "Input your existing PW first.";
				else if (PW != userInfo[loginIndex][1]) TB_Message.Text = "The PW is not correct.";
				else {
					TB_PW.Text = "";
					TB_Register.Text = "Continue";
					TB_FindID.Text = "Cancel";
					changePWFlag = true;
					TB_Register_PreviewMouseLeftButtonDown(sender, e);
				}
			}

			// ID 찾기
		}

		private void TB_FindID_MouseLeave(object sender, MouseEventArgs e) {
			TB_FindID.TextDecorations = null;
		}

		// 메세지 출력
		private void MessageShow(string msg) {
			//Dim doubleAnimation
			DoubleAnimation doubleAnimation = new DoubleAnimation(1.0, 0.0, TimeSpan.FromSeconds(2));
			DoubleAnimation doubleAnimation2 = new DoubleAnimation(0.0, 1.0, TimeSpan.FromSeconds(2));
			RepeatBehavior repeatBehavior;


			//TB_Message.BeginAnimation(OpacityProperty, doubleAnimation);
			TB_Message.BeginAnimation(OpacityProperty, doubleAnimation);
			TB_Message.Text = msg;
		}

		// 파일 읽기
		private List<string[]> LoadFile(string fileName, int codingPar) {
			List<string[]> sTempList = new List<string[]>();
			if (File.Exists(fileName)) {
				using (StreamReader sr = new StreamReader(fileName, Encoding.GetEncoding(932))) {
					for (int i=0; sr.Peek() >= 0; i++) {
						string[] sTemp = sr.ReadLine().Split('\t');
						if (sTemp.Length == 1) sTemp = new string[] { sTemp[0], "" }; // 배열길이는 null이 아니면 최소 2여야 함.
						for(int j=0; j<sTemp.Length; j++) {
							sTemp[j] = code(sTemp[j], codingPar);
						}
						sTempList.Add(sTemp);
					}
					sr.Close();
					sr.Dispose();
				}
			}
			return sTempList;
		}

		// 파일 쓰기
		private void SaveFile(string fileName, List<string[]> Info, int codingPar) {
			using (FileStream fi = new FileStream(fileName, FileMode.Create))
			using (StreamWriter sw = new StreamWriter(fi, Encoding.GetEncoding(932))) {
				StringBuilder sb = new StringBuilder();
				for(int i=0; i<Info.Count; i++) {
					for(int j=0; j<Info[i].Length; j++) {
						sb.Append(code(Info[i][j], codingPar) + "\t");
					}
					sb.Remove(sb.Length -1, 1);
					sb.Append("\n");
				}
				sb.Remove(sb.Length - 1, 1);
				sw.Write(sb);
				sw.Close();
				sw.Dispose();
				fi.Close();
				fi.Dispose();
			}
		}

		// 암호화 및 복호화
		private string code(string input, int codingPar) {
			StringBuilder output = new StringBuilder();
			for(int i=0; i<input.Length; i++) {
				output.Append((char) ((int) input[i] + codingPar));
			}
			return output.ToString();
		}

		// PW 입력기능
		private void TB_PW_TextChanged(object sender, TextChangedEventArgs e) {
			// 함수의 자기호출 방지 설정
			if (PWEditableFlag) PWEditableFlag = false;
			else return;

			// 텍스트 수정 정보
			int offset = e.Changes.ElementAt(0).Offset;
			int removedLength = e.Changes.ElementAt(0).RemovedLength;
			int addedLength = e.Changes.ElementAt(0).AddedLength;

			// 지워진 텍스트 삭제
			PW = PW.Remove(offset, e.Changes.ElementAt(0).RemovedLength);

			// 입력된 텍스트 추가
			string sTemp = (TB_PW.Text.Remove(0, offset)).Remove(addedLength, TB_PW.Text.Length - ( offset + addedLength));
			PW = PW.Insert(offset, sTemp);
			
			// 암호 숨기기
			string sTemp2 = "*************";
			TB_PW.Text = sTemp2.Remove(TB_PW.Text.Length);

			// 텍스트박스 입력 커서 위치 갱신
			TB_PW.CaretIndex = offset + addedLength;

			// 함수의 자기호출 방지 해제
			PWEditableFlag = true;
		}
	}
}
