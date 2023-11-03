using System.Globalization;
using System.Numerics;

namespace GenericMaths {
  // public partial class OlisNumber : INumber<OlisNumber> {
  //   // For the demo, I implemented only this method, by deferring to `int`
  //   public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format,
  //     IFormatProvider? provider) {
  //     var intValNumber = intVal as INumber<int>;
  //     return intValNumber.TryFormat(destination, out charsWritten, format, provider);
  //   }
  //
  //   public int CompareTo(object? obj) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public int CompareTo(OlisNumber? other) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public virtual bool Equals(OlisNumber? other) {
  //     if (ReferenceEquals(null, other)) {
  //       return false;
  //     }
  //
  //     if (ReferenceEquals(this, other)) {
  //       return true;
  //     }
  //
  //     return intVal == other.intVal;
  //   }
  //
  //   public string ToString(string? format, IFormatProvider? formatProvider) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static OlisNumber Parse(string s, IFormatProvider? provider) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool TryParse(string? s, IFormatProvider? provider, out OlisNumber result) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static OlisNumber Parse(ReadOnlySpan<char> s, IFormatProvider? provider) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out OlisNumber result) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static OlisNumber AdditiveIdentity { get; }
  //
  //   public static bool operator >(OlisNumber left, OlisNumber right) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool operator >=(OlisNumber left, OlisNumber right) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool operator <(OlisNumber left, OlisNumber right) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool operator <=(OlisNumber left, OlisNumber right) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static OlisNumber operator --(OlisNumber value) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static OlisNumber operator /(OlisNumber left, OlisNumber right) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static OlisNumber operator ++(OlisNumber value) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static OlisNumber operator %(OlisNumber left, OlisNumber right) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static OlisNumber MultiplicativeIdentity { get; }
  //
  //   public static OlisNumber operator *(OlisNumber left, OlisNumber right) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static OlisNumber operator -(OlisNumber left, OlisNumber right) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static OlisNumber operator -(OlisNumber value) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static OlisNumber operator +(OlisNumber value) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static OlisNumber Abs(OlisNumber value) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool IsCanonical(OlisNumber value) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool IsComplexNumber(OlisNumber value) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool IsEvenInteger(OlisNumber value) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool IsFinite(OlisNumber value) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool IsImaginaryNumber(OlisNumber value) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool IsInfinity(OlisNumber value) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool IsInteger(OlisNumber value) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool IsNaN(OlisNumber value) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool IsNegative(OlisNumber value) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool IsNegativeInfinity(OlisNumber value) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool IsNormal(OlisNumber value) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool IsOddInteger(OlisNumber value) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool IsPositive(OlisNumber value) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool IsPositiveInfinity(OlisNumber value) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool IsRealNumber(OlisNumber value) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool IsSubnormal(OlisNumber value) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool IsZero(OlisNumber value) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static OlisNumber MaxMagnitude(OlisNumber x, OlisNumber y) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static OlisNumber MaxMagnitudeNumber(OlisNumber x, OlisNumber y) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static OlisNumber MinMagnitude(OlisNumber x, OlisNumber y) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static OlisNumber MinMagnitudeNumber(OlisNumber x, OlisNumber y) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static OlisNumber Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static OlisNumber Parse(string s, NumberStyles style, IFormatProvider? provider) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool TryConvertFromChecked<TOther>(TOther value, out OlisNumber result)
  //     where TOther : INumberBase<TOther> {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool TryConvertFromSaturating<TOther>(TOther value, out OlisNumber result)
  //     where TOther : INumberBase<TOther> {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool TryConvertFromTruncating<TOther>(TOther value, out OlisNumber result)
  //     where TOther : INumberBase<TOther> {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool TryConvertToChecked<TOther>(OlisNumber value, out TOther result)
  //     where TOther : INumberBase<TOther> {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool TryConvertToSaturating<TOther>(OlisNumber value, out TOther result)
  //     where TOther : INumberBase<TOther> {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool TryConvertToTruncating<TOther>(OlisNumber value, out TOther result)
  //     where TOther : INumberBase<TOther> {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider,
  //     out OlisNumber result) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool TryParse(string? s, NumberStyles style, IFormatProvider? provider, out OlisNumber result) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static OlisNumber One { get; }
  //   public static int Radix { get; }
  //   public static OlisNumber Zero { get; }
  //
  //   public static bool operator ==(OlisNumber? left, OlisNumber? right) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public static bool operator !=(OlisNumber? left, OlisNumber? right) {
  //     throw new NotImplementedException();
  //   }
  //
  //   public override bool Equals(object? obj) {
  //     if (ReferenceEquals(null, obj)) {
  //       return false;
  //     }
  //
  //     if (ReferenceEquals(this, obj)) {
  //       return true;
  //     }
  //
  //     if (obj.GetType() != this.GetType()) {
  //       return false;
  //     }
  //
  //     return Equals((OlisNumber)obj);
  //   }
  //
  //   public override int GetHashCode() {
  //     return intVal;
  //   }
  // }
}