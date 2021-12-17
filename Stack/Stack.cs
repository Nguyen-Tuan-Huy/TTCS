using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Stack
    {
        string infix;
		string[] stack = new string[20];
        int top;
		public Stack() {
			this.top = -1;
		}

		public void getInfix()
		{
			string value;
			Console.WriteLine("Nhap bieu thuc(Cac phan tu cach nhau 1 khoang trang: ");
			value = Console.ReadLine();
			this.infix = value;
		}

		void Push(string x)
		{
				this.top++; // vi trí phan tu moi
				this.stack[this.top] = x; // dua pt moi vào stack
		}

		string Pop()
		{
			if (this.top == -1) // stack rong, return 0
				return "";
			else
			{
				string key = this.stack[this.top]; // lay phan tu khoi stack
				this.stack[this.top] = "";
				this.top -= 1; // chi den phan tt tiep theo
				return key; // Pop thành công return 1
			}
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
			string[] infixArr = this.infix.Split(' ');
			foreach (string val in infixArr)
			{
				if (int.TryParse(val, out int num))
					postfix += val.ToString() + " ";
				else 
					if(val.CompareTo("(") == 0)
						Push(val);
					else 
						if(val.CompareTo(")") == 0)
						{
							string x = Pop();
							while (x.CompareTo("(") != 0)
							{
								postfix += x + " ";
								x = Pop();
							}	
						}
						else
						{
							while(this.top > -1 && precedence(val) <= precedence(this.stack[this.top]))
							{
								postfix += Pop() + " ";
							}
							Push(val);
						}
			}
			
			while(top > -1)
			{
				postfix += Pop() + " ";
			}

			return postfix;
		}

		public float countEvaluate()
		{
			string result;
			string[] postfixArr = infixtoPostfix().Trim().Split(' ');
			Console.WriteLine("Chuyen sang bieu thuc hau to: ");
			foreach (string val in postfixArr)
			{
				Console.Write(val);
				//Console.WriteLine("value: " + val);
				if (int.TryParse(val, out int num))
					Push(val);
				else
				{
					string t1 = Pop();
					string t2 = Pop();
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
							Console.WriteLine("\nInvalid Operator");
							return 0;
					}
					Push(result);

				}
			}
			result = Pop();
			return (Convert.ToSingle(result));
			//return 0;
		}

	}
}
