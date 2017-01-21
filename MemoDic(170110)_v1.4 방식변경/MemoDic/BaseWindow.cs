using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using System.Collections;
using System.ComponentModel;
using System.Security;
using System.Windows.Automation.Peers;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shell;

namespace MemoDic {
	public abstract class BaseWindow : Window {
		bool PWEncodingFlag = false;
		string PW = "";
		
		// PW 입력기능
		private void TB_PW_TextChanged(object sender, TextChangedEventArgs e) {
			TextBox textBox = (TextBox)sender;

			// 함수의 자기호출 방지 설정
			if (PWEncodingFlag) return;
			else PWEncodingFlag = true;
			
			// 텍스트 수정 정보
			int offset = e.Changes.ElementAt(0).Offset;
			int removedLength = e.Changes.ElementAt(0).RemovedLength;
			int addedLength = e.Changes.ElementAt(0).AddedLength;

			// 지워진 텍스트 삭제
			PW = PW.Remove(offset, e.Changes.ElementAt(0).RemovedLength);

			// 입력된 텍스트 추가
			string sTemp = (textBox.Text.Remove(0, offset)).Remove(addedLength, textBox.Text.Length - (offset + addedLength));
			PW = PW.Insert(offset, sTemp);

			// 암호 숨기기
			string sTemp2 = "*************";
			textBox.Text = sTemp2.Remove(textBox.Text.Length);

			// 텍스트박스 입력 커서 위치 갱신
			textBox.CaretIndex = offset + addedLength;

			// 함수의 자기호출 방지 해제
			PWEncodingFlag = false;
		}
	}
}
