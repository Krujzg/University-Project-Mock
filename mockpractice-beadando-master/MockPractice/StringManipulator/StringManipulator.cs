using System.Linq;

namespace MockPractice.StringManipulator
{
//HW TESTS
	public class StringManipulator
	{
        //private?
		public bool IsVowel(char c)
		{
			var vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
			return vowels.Contains(c);
		}

		public string Transform(string s)
		{
			var lc = s.ToLower();
			var x = lc.Where(c => IsVowel(c));
			var y = lc.Where(c => !IsVowel(c));

			return new string(x.Concat(y).ToArray());
		}
	}
}
