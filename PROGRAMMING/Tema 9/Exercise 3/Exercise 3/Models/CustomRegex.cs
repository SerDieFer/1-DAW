using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise_3
{
    static class CustomRegex
    {
        public static bool RegexName(string x)
        {
            /* THIS METHOD VALIDATES WHETHER THE INPUT STRING CONTAINS ONLY LETTERS, DIACRITICAL MARKS, AND SPECIFIC SYMBOLS, ALLOWING FOR MULTIPLE WORDS SEPARATED BY A SINGLE SPACE.
             * THE REGULAR EXPRESSION PATTERN "^[a-zA-Zá-ýÁ-Ý0-9?!$&-_]+$" ENSURES THAT THE STRING STARTS AND ENDS WITH AT LEAST ONE OCCURRENCE OF LETTERS, DIACRITICAL MARKS, OR SPECIFIC SYMBOLS, 
             * AND CAN BE FOLLOWED BY ZERO OR MORE OCCURRENCES OF A SPACE AND ANOTHER WORD. */

            string regexPattern = "^[a-zA-Zá-ýÁ-Ý0-9?!$&-_]+$";
            return new Regex(regexPattern).IsMatch(x);
        }

        public static bool RegexEmail(string x)
        {
            /* THIS METHOD VALIDATES WHETHER THE INPUT STRING REPRESENTS A VALID EMAIL ADDRESS.
             * THE REGULAR EXPRESSION PATTERN "^[a-zA-Z0-9]+[@]{1}[a-zA-Z0-9]+[.]{1}[a-z]{2,3}$" ENSURES THAT THE STRING STARTS WITH ONE OR MORE ALPHANUMERIC CHARACTERS (LETTERS OR DIGITS) 
             * FOLLOWED BY THE "@" SYMBOL AND THE DOMAIN "x.x" AT THE END OF THE STRING. */

            string regexPattern = "^[a-zA-Z0-9]+[@]{1}[a-zA-Z0-9]+[.]{1}[a-z]{2,3}$";
            return new Regex(regexPattern).IsMatch(x);
        }

        public static bool RegexPassword(string x)
        {
            /* THIS METHOD VALIDATES WHETHER THE INPUT STRING REPRESENTS A VALID PASSWORD.
             * THE REGULAR EXPRESSION PATTERN "^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[@$!%*?&])[A-Za-z[0-9]@$!%*?&]{8,}$" ENSURES THAT THE STRING:
             * CONTAINS AT LEAST EIGHT CHARACTERS,
             * INCLUDES AT LEAST ONE LOWERCASE LETTER (a-z),
             * INCLUDES AT LEAST ONE UPPERCASE LETTER (A-Z),
             * INCLUDES AT LEAST ONE DIGIT (0-9),
             * INCLUDES AT LEAST ONE SPECIAL CHARACTER FROM THE SET $!%*?& */

            string regexPattern = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-_]).{8,}$";
            return new Regex(regexPattern).IsMatch(x);
        }
    }
}
