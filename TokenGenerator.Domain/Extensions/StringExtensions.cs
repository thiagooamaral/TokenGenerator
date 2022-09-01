namespace TokenGenerator.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string GetLastDigits(this string source, int length)
        {
            if (length >= source.Length) return source;

            return source.Substring(source.Length - length);
        }
    }
}