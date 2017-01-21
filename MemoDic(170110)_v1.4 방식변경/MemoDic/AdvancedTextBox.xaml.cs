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

namespace MemoDic {
	/// <summary>
	/// Interaction logic for AdvancedTextBox.xaml
	/// </summary>
	public partial class AdvancedTextBox : UserControl {
		private bool PWEncodingFlag = false;
		public string InputText;

		public AdvancedTextBox() {
			InitializeComponent();
			InputText = "";
		}

		// 워터마크 기능
		private string watermark = "Watermark";
		public string Watermark {
			get {
				return watermark;
			}
			set {
				watermark = value;
				TBL_Watermark.Text = watermark;
			}
		}

		// 보안기능
		private bool security = false;
		public bool Security {
			get {
				return security;
			}
			set {
				security = value;
			}
		}

		private void TB_TextBox_TextChanged(object sender, TextChangedEventArgs e) {
			if (security) {
				// 함수의 자기호출 방지 설정
				if (PWEncodingFlag) return;
				else PWEncodingFlag = true;

				// 텍스트 수정 정보
				int offset = e.Changes.ElementAt(0).Offset;
				int removedLength = e.Changes.ElementAt(0).RemovedLength;
				int addedLength = e.Changes.ElementAt(0).AddedLength;

				// 지워진 텍스트 삭제
				InputText = InputText.Remove(offset, e.Changes.ElementAt(0).RemovedLength);

				// 입력된 텍스트 추가
				string sTemp = (TB_TextBox.Text.Remove(0, offset)).Remove(addedLength, TB_TextBox.Text.Length - (offset + addedLength));
				InputText = InputText.Insert(offset, sTemp);

				// 암호 숨기기
				string sTemp2 = "*************";
				TB_TextBox.Text = sTemp2.Remove(TB_TextBox.Text.Length);

				// 텍스트박스 입력 커서 위치 갱신
				TB_TextBox.CaretIndex = offset + addedLength;

				// 함수의 자기호출 방지 해제
				PWEncodingFlag = false;
			}
			else {
				InputText = TB_TextBox.Text;
			}
			CustomMethod();
		}

		protected virtual void CustomMethod() {
			
		}
	}
}
