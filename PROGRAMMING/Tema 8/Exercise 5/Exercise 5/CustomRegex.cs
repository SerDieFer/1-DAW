using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise_5
{
    static class CustomRegex
    {
        public static bool RegexID(string x)
        {
            /* THIS METHOD VALIDATES WHETHER THE INPUT STRING FOLLOWS THE PATTERN OF A VALID ID.
                * THE REGULAR EXPRESSION PATTERN "^[A-Z]{1}[0-9]{7}[A-Z]{1}$|^[0-9]{8}[A-Z]{1}$" CHECKS FOR TWO POSSIBLE FORMATS:
                * ONE LETTER, FOLLOWED BY SEVEN DIGITS, AND THEN ANOTHER LETTER. EIGHT DIGITS, FOLLOWED BY ONE LETTER. */

            string regexPattern = "^[a-zA-Z]{1}[0-9]{7}[a-zA-Z]{1}$|^[0-9]{8}[a-zA-Z]{1}$";
            return new Regex(regexPattern).IsMatch(x);
        }
        public static bool RegexName(string x)
        {
            /* THIS METHOD VALIDATES WHETHER THE INPUT STRING CONTAINS ONLY LETTERS AND DIACRITICAL MARKS, ALLOWING FOR MULTIPLE WORDS SEPARATED BY A SINGLE SPACE.
                * THE REGULAR EXPRESSION PATTERN "^[A-ZÁ-Ý]+( [A-ZÁ-Ý]+)*$" ENSURES THAT THE STRING STARTS WITH AT LEAST ONE WORD(INCLUDING UPPERCASE AND DIACRITICAL MARKS) 
                * AND CAN BE FOLLOWED BY ZERO OR MORE OCCURRENCES OF A SPACE AND ANOTHER WORD. */

            string regexPattern = "^[a-zA-Zá-ýÁ-Ý]+( [a-zA-Zá-ýÁ-Ý]+)*$";
            return new Regex(regexPattern).IsMatch(x);
        }

        public static bool RegexPhone(string x)
        {
            /* THIS METHOD VALIDATES WHETHER THE INPUT STRING REPRESENTS A VALID PHONE NUMBER.
                * THE REGULAR EXPRESSION PATTERN "^[6-7][0-9]{8}$" ENSURES THAT THE STRING STARTS WITH EITHER 6 OR 7, FOLLOWED BY EIGHT DIGITS. */

            string regexPattern = "^[6-7][0-9]{8}$";
            return new Regex(regexPattern).IsMatch(x);
        }

        public static bool RegexEmail(string x)
        {
            /* THIS METHOD VALIDATES WHETHER THE INPUT STRING REPRESENTS A VALID EMAIL ADDRESS.
                 * THE REGULAR EXPRESSION PATTERN "^[a-zA-Z0-9]+@edu\.gva\.es$" ENSURES THAT THE STRING STARTS WITH ONE OR MORE ALPHANUMERIC CHARACTERS (LETTERS OR DIGITS) 
                 * FOLLOWED BY THE "@" SYMBOL AND THE SPECIFIC DOMAIN "edu.gva.es" AT THE END OF THE STRING. */

            string regexPattern = "^[a-zA-Z0-9]+(@edu.gva.es)";
            return new Regex(regexPattern).IsMatch(x);
        }

        public static bool RegexCourseCod(string x)
        {
            /* THIS METHOD VALIDATES WHETHER THE INPUT STRING REPRESENTS A VALID COURSE CODE.
                * THE REGULAR EXPRESSION PATTERN "^(0|[1-9][0-9]*)$" CHECKS IF THE STRING IS EITHER '0' OR A POSITIVE INTEGER.*/

            string regexPattern = "^(0|[1-9][0-9]*)$";
            return new Regex(regexPattern).IsMatch(x);
        }

        public static bool RegexGradeValue(string x)
        {
            /* THIS METHOD VALIDATES WHETHER THE INPUT STRING REPRESENTS A VALID GRADE VALUE.
                 * THE REGULAR EXPRESSION PATTERN "^(10(\.0+)?|[0-9](\.[0-9]+)?)$" ENSURES THAT THE STRING MATCHES THE FOLLOWING CRITERIA:
                 * ^            : ASSERTS THE START OF THE STRING.
                 * (            : START OF THE GROUP FOR MATCHING EITHER:
                 * 10(\.0+)?    : MATCH '10' OPTIONALLY FOLLOWED BY A DOT AND ONE OR MORE '0'S (E.G., 10, 10.0, 10.00).
                 * |            : OR
                 * [0-9]        : MATCH ANY DIGIT FROM 0 TO 9 (THE FIRST DIGIT OF A NUMBER).
                 * (\.[0-9]+)?  : OPTIONALLY MATCH A DOT FOLLOWED BY ONE OR MORE DIGITS (TO ALLOW DECIMALS LIKE 7.5, 8.9).
                 * )            : END OF THE GROUP FOR MATCHING EITHER.
                 * $            : ASSERTS THE END OF THE STRING. */

            string regexPattern = "^(10(\\.0+)?|[0-9](\\.[0-9]+)?)$";
            return new Regex(regexPattern).IsMatch(x);
        }
    }
}
