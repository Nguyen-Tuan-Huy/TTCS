using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Stack
    {
        string infix; // Biểu thức
		string[] stack = new string[20]; // Ngăn xếp stack
        int top = -1;	// Phần tử trên cùng của stack
		public Stack() {}

		void push(string item)
		{
			this.top++; // vi trí phần tử mới
			this.stack[this.top] = item; // Đưa phần tử mới vào stack
		}

		string pop()
		{
			if (this.top == -1) // stack rỗng
				return "";
			else
			{
				string key = this.stack[this.top]; // Lấy phần tử ra khỏi stack
				this.stack[this.top] = "";
				this.top -= 1; // Chỉ đến phần tử tiếp theo
				return key; // pop thành công
			}
		}

		public void getInfix()
		{
			string value;
			Console.WriteLine("Nhap bieu thuc(Cac phan tu cach nhau 1 khoang trang): ");
			value = Console.ReadLine();
			this.infix = value;
		}

		int precedence(string x)
		{
			if (x.CompareTo("(") == 0)
				return 0;
			if (x.CompareTo("+") == 0 || x.CompareTo("-") == 0)
				return 1;
			if (x.CompareTo("*") == 0 || x.CompareTo("/") == 0 || x.CompareTo("%") == 0)
				return 2;
			return 3;
		}

		string infixtoPostfix()
		{
			string postfix = "";
			string[] infixArr = this.infix.Split(' ');// Tách riêng biệt từng phần tử
			foreach (string val in infixArr) // Duyệt toàn bộ phần tử
			{
				if (int.TryParse(val, out int num))
					postfix += val.ToString() + " ";
				else 
					if(val.CompareTo("(") == 0)
						push(val);
					else 
						if(val.CompareTo(")") == 0)
						{
							string x = pop();
							while (x.CompareTo("(") != 0)
							{
								postfix += x + " ";
								x = pop();
							}	
						}
						else
						{
							while(this.top > -1 && precedence(val) <= precedence(this.stack[this.top]))
							{
								postfix += pop() + " ";
							}
							push(val);
						}
			}
			
			while(top > -1) // pop toàn bộ phần từ trong stack
			{
				postfix += pop() + " ";
			}

			return postfix;
		}

		public float countEvaluate()
		{
			string result;
			string[] postfixArr = infixtoPostfix().Trim().Split(' ');
			Console.WriteLine("\n==============================\nChuyen sang bieu thuc hau to: ");
			foreach (string val in postfixArr)
			{
				Console.Write(val);
				if (int.TryParse(val, out int num))
					push(val);
				else
				{
					string t1 = pop(), t2 = pop();
					float pop1, pop2;
					Single.TryParse(t1, out pop1);
					Single.TryParse(t2, out pop2);
					switch (val)
					{
						case "+":
							result = (pop2 + pop1).ToString();
							break;
						case "-":
							result = (pop2 - pop1).ToString();
							break;
						case "/":
							result = (pop2 / pop1).ToString();
							break;
						case "*":
							result = (pop2 * pop1).ToString();
							break;
						default:
							Console.WriteLine("\nToan tu khong hop le");
							return 0;
					}
					push(result);

				}
			}
			result = pop();
			return (Convert.ToSingle(result));
		}
	}
}
