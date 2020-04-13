using System;
using System.IO;
using System.Text.RegularExpressions;

namespace JPProject.Domain.Core.Util
{
    public static class StringExtensions
    {
        private static char sensitive = '*';
        private static char at = '@';

        public static string UrlEncode(this string url)
        {
            return Uri.EscapeDataString(url);
        }
        public static bool NotEqual(this string original, string compareTo)
        {
            return !original.Equals(compareTo);
        }
        public static bool IsEmail(this string username)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(username, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsMissing(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsPresent(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        private static string UrlCombine(string path1, string path2)
        {
            path1 = path1.TrimEnd('/') + "/";
            path2 = path2.TrimStart('/');

            return Path.Combine(path1, path2)
                .Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        }
        public static string UrlPathCombine(this string path1, params string[] path2)
        {
            path1 = path1.TrimEnd('/') + "/";
            foreach (var s in path2)
            {
                path1 = UrlCombine(path1, s).Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            }

            return path1;

        }

        public static string AddSpacesToSentence(this string state)
        {
            var text = state.ToCharArray();
            var chars = new char[text.Length + HowManyCapitalizedChars(text) - 1];

            chars[0] = text[0];
            int j = 1;
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                {
                    if (text[i - 1] != ' ' && !char.IsUpper(text[i - 1]) ||
                        (char.IsUpper(text[i - 1]) && i < text.Length - 1 && !char.IsUpper(text[i + 1])))
                    {
                        chars[j++] = ' ';
                        chars[j++] = text[i];
                        continue;
                    }
                }

                chars[j++] = text[i];
            }

            return new string(chars.AsSpan());
        }
        private static int HowManyCapitalizedChars(char[] state)
        {
            var count = 0;
            for (var i = 0; i < state.Length; i++)
            {
                if (char.IsUpper(state[i]))
                    count++;
            }

            return count;
        }

        public static bool HasTrailingSlash(this string url)
        {
            return url != null && url.EndsWith("/");
        }


        public static string TruncateSensitiveInformation(this string part)
        {
            return part.AsSpan().TruncateSensitiveInformation();
        }

        public static string TruncateSensitiveInformation(this ReadOnlySpan<char> part)
        {
            var firstAndLastLetterBuffer = new char[2];
            var firstAndLastLetter = new Span<char>(firstAndLastLetterBuffer);

            if (part != "")
            {
                part.Slice(0, 1).CopyTo(firstAndLastLetter.Slice(0, 1));
                part.Slice(part.Length - 1).CopyTo(firstAndLastLetter.Slice(1));

                return string.Create(part.Length, firstAndLastLetterBuffer, (span, s) =>
                {
                    s.AsSpan(0, 1).CopyTo(span);
                    for (var i = 1; i < span.Length - 1; i++)
                    {
                        span[i] = sensitive;
                    }
                    s.AsSpan(s.Length - 1).CopyTo(span.Slice(span.Length - 1));
                });
            }
            else
            {
                return "";
            }

        }

        public static string TruncateEmail(this string email)
        {
            var beforeAt = email.AsSpan(0, email.IndexOf(at)).TruncateSensitiveInformation().AsSpan();
            var afterAt = email.AsSpan(email.IndexOf(at) + 1).TruncateSensitiveInformation().AsSpan();

            var finalSpan = new Span<char>(new char[email.Length]);

            beforeAt.CopyTo(finalSpan);
            finalSpan[beforeAt.Length] = at;
            afterAt.CopyTo(finalSpan.Slice(beforeAt.Length + 1));

            return finalSpan.ToString();
        }
    }
}
