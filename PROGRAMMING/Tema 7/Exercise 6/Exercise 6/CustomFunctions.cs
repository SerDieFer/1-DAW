using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise_6
{
    static class CustomFunctions
    {

        public static bool RegexID(string x)
        {
            /* THIS REGULAR EXPRESSION HAS THIS CONDITIONS:
             * ^: THIS SYMBOL DENOTES THE BEGINNING OF THE STRING.
             * 0-9 MATCHES A SINGLE CHARACTER IN THE RANGE BETWEEN 0 (INDEX 48) AND 9 (INDEX 57) (CASE SENSITIVE)
             * * $: THIS SYMBOL INDICATES THE END OF THE STRING AND ENDS UPPERCASE CONVERSION.
             * SO TO SUM UP, THIS SELECTS ONLY NUMBERS IN THE WHOLE STRING */

            string regexPattern = "^[a-zA-Z]{1}[0-9]{7}[a-zA-Z]{1}$|^[0-9]{8}[a-zA-Z]{1}$";
            return new Regex(regexPattern).IsMatch(x);
        }
        public static bool RegexName(string x)
        {
            /* THIS REGULAR EXPRESSION HAS THIS CONDITIONS:
             * ^: THIS SYMBOL DENOTES THE BEGINNING OF THE STRING.
             * [A-ZÁ-Ý]+: IN THIS PART, WE USE \U TO BEGIN UPPERCASE CONVERSION, SPECIFYING THAT THE STRING MUST START WITH AT LEAST ONE LETTER OR ACCENTED CHARACTER. 
             * THE [A-ZÁ-Ý] PORTION ALLOWS BOTH UPPERCASE AND ACCENTED CHARACTERS FROM THE SPANISH ALPHABET.
             * ( \U[A-ZÁ-Ý]+)*: THIS SECTION ALLOWS ZERO OR MORE REPETITIONS OF A SPACE FOLLOWED BY ANOTHER WORD. 
             * WITHIN THE PARENTHESES ( ), WE HAVE \U TO CONTINUE UPPERCASE CONVERSION, A SPACE FOLLOWED BY THE SAME EXPRESSION [A-ZÁ-Ý]+
             * INDICATING THAT THERE CAN BE MULTIPLE WORDS SEPARATED BY A SINGLE SPACE.
             * $: THIS SYMBOL INDICATES THE END OF THE STRING AND ENDS UPPERCASE CONVERSION. 
             * SO TO SUM UP, THIS SELECTS ONLY LETTERS AND DIACRITICAL MARKS WHICH CAN BE SEPARATED BY A SINGLE SPACE IN THE WHOLE STRING */

            string regexPattern = "^[a-zA-Zá-ýÁ-Ý]+( [a-zA-Zá-ýÁ-Ý]+)*$";
            return new Regex(regexPattern).IsMatch(x);
        }

        public static bool RegexPhone(string x)
        {
            /* THIS REGULAR EXPRESSION HAS THIS CONDITIONS:
             * ^: THIS SYMBOL DENOTES THE BEGINNING OF THE STRING.
             * 0-9 MATCHES A SINGLE CHARACTER IN THE RANGE BETWEEN 0 (INDEX 48) AND 9 (INDEX 57) (CASE SENSITIVE)
             * * $: THIS SYMBOL INDICATES THE END OF THE STRING AND ENDS UPPERCASE CONVERSION.
             * SO TO SUM UP, THIS SELECTS ONLY NUMBERS IN THE WHOLE STRING */

            string regexPattern = "^[6-7][0-9]{8}$";
            return new Regex(regexPattern).IsMatch(x);
        }
        public static bool RegexCourseCod(string x)
        {
            /* THIS REGULAR EXPRESSION HAS THIS CONDITIONS:
             * ^: THIS SYMBOL DENOTES THE BEGINNING OF THE STRING.
             * 0-9 MATCHES A SINGLE CHARACTER IN THE RANGE BETWEEN 0 (INDEX 48) AND 9 (INDEX 57) (CASE SENSITIVE)
             * * $: THIS SYMBOL INDICATES THE END OF THE STRING AND ENDS UPPERCASE CONVERSION.
             * SO TO SUM UP, THIS SELECTS ONLY NUMBERS IN THE WHOLE STRING */

            string regexPattern = "^(0|[1-9][0-9]*)$";
            return new Regex(regexPattern).IsMatch(x);
        }
    }
}
