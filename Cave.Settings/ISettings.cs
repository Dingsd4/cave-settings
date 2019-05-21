using System;
using System.Globalization;

namespace Cave
{
    /// <summary>
    /// Provides an interface for reading settings.
    /// </summary>
    public interface ISettings
    {
        /// <summary>
        /// Gets the name of the settings.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Obtains whether a specified section exists or not.
        /// </summary>
        /// <param name="section">Section to search.</param>
        /// <returns>Returns true if the sections exists false otherwise.</returns>
        bool HasSection(string section);

        /// <summary>
        /// Obtains all section names present at the file.
        /// </summary>
        /// <returns>Returns an array of all section names.</returns>
        string[] GetSectionNames();

        /// <summary>
        /// Reads a whole section from the settings (automatically removes empty lines and comments).
        /// </summary>
        /// <param name="section">Name of the section.</param>
        /// <returns>Returns an array of string containing all section names.</returns>
        string[] ReadSection(string section);

        /// <summary>
        /// Reads a whole section from the settings.
        /// </summary>
        /// <param name="section">Name of the section.</param>
        /// <param name="remove">Remove comments and empty lines.</param>
        /// <returns>Returns the whole section as string array.</returns>
        string[] ReadSection(string section, bool remove);

        /// <summary>
        /// Reads a setting from the settings.
        /// </summary>
        /// <param name="section">Sectionname of the setting.</param>
        /// <param name="name">Name of the setting.</param>
        /// <returns>Returns null if the setting is not present a string otherwise.</returns>
        string ReadSetting(string section, string name);

        /// <summary>
        /// Reads a whole section as values of an enum and returns them as array.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="section">The Section to read.</param>
        /// <param name="throwEx">Throw an error for any unknown value in the section.</param>
        /// <returns>Returns an array of values.</returns>
        T[] ReadEnums<T>(string section, bool throwEx)
            where T : struct;

        /// <summary>
        /// Reads a whole section as values of a struct.
        /// </summary>
        /// <typeparam name="T">The type of the struct.</typeparam>
        /// <param name="section">Section to read.</param>
        /// <param name="throwEx">Throw an error for any unset value in the section.</param>
        /// <returns>Returns a new struct instance.</returns>
        T ReadStruct<T>(string section, bool throwEx = true)
            where T : struct;

        /// <summary>
        /// Reads a whole section as values of a struct.
        /// </summary>
        /// <param name="section">Section to read.</param>
        /// <param name="container">Container to set the field at.</param>
        /// <param name="throwEx">Throw an error for any unset value in the section.</param>
        /// <returns>Returns true if all fields could be read. Throws an exception or returns false otherwise.</returns>
        /// <typeparam name="T">Structure type.</typeparam>
        bool ReadStruct<T>(string section, ref T container, bool throwEx = true)
            where T : struct;

        /// <summary>
        /// Reads a whole section as values of a struct.
        /// </summary>
        /// <typeparam name="T">The type of the struct.</typeparam>
        /// <param name="section">Section to read.</param>
        /// <param name="throwEx">Throw an error for any invalid value in the section.</param>
        /// <returns>Returns a new struct instance.</returns>
        T ReadObject<T>(string section, bool throwEx = true)
            where T : class, new();

        /// <summary>
        /// Reads a whole section as values of an object (this does not work with structs).
        /// </summary>
        /// <param name="section">Section to read.</param>
        /// <param name="container">Container to set the field at.</param>
        /// <param name="throwEx">Throw an error for any unset value in the section.</param>
        /// <returns>Returns true if all fields could be read. Throws an exception or returns false otherwise.</returns>
        bool ReadObject(string section, object container, bool throwEx = true);

        /// <summary>
        /// Gets a value indicating whether the config can be reload.
        /// </summary>
        bool CanReload { get; }

        /// <summary>
        /// Reload the whole config.
        /// </summary>
        void Reload();

        /// <summary>
        /// Gets the culture used to decode values.
        /// </summary>
        CultureInfo Culture { get; }

        #region Read Value Members

        /// <summary>Reads a string value.</summary>
        /// <param name="section">The section.</param>
        /// <param name="name">The name.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <exception cref="ArgumentException">If no default value is specified an ArgumentException will be thrown.</exception>
        /// <returns>Returns the (converted) value if a value is present or the default value if not.</returns>
        string ReadString(string section, string name, string defaultValue = null);

        /// <summary>
        /// Reads a bool value.
        /// </summary>
        /// <param name="section">The section.</param>
        /// <param name="name">The name.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <exception cref="ArgumentException">If no default value is specified an ArgumentException will be thrown.</exception>
        /// <returns>Returns the (converted) value if a value is present or the default value if not.</returns>
        bool ReadBool(string section, string name, bool? defaultValue = null);

        /// <summary>
        /// Reads a int32 value.
        /// </summary>
        /// <param name="section">The section.</param>
        /// <param name="name">The name.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <exception cref="ArgumentException">If no default value is specified an ArgumentException will be thrown.</exception>
        /// <returns>Returns the (converted) value if a value is present or the default value if not.</returns>
        int ReadInt32(string section, string name, int? defaultValue = null);

        /// <summary>
        /// Reads a uint32 value.
        /// </summary>
        /// <param name="section">The section.</param>
        /// <param name="name">The name.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <exception cref="ArgumentException">If no default value is specified an ArgumentException will be thrown.</exception>
        /// <returns>Returns the (converted) value if a value is present or the default value if not.</returns>
        uint ReadUInt32(string section, string name, uint? defaultValue = null);

        /// <summary>
        /// Reads a int64 value.
        /// </summary>
        /// <param name="section">The section.</param>
        /// <param name="name">The name.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <exception cref="ArgumentException">If no default value is specified an ArgumentException will be thrown.</exception>
        /// <returns>Returns the (converted) value if a value is present or the default value if not.</returns>
        long ReadInt64(string section, string name, long? defaultValue = null);

        /// <summary>Reads a uint64 value.</summary>
        /// <param name="section">The section.</param>
        /// <param name="name">The name.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <exception cref="ArgumentException">If no default value is specified an ArgumentException will be thrown.</exception>
        /// <returns>Returns the (converted) value if a value is present or the default value if not.</returns>
        ulong ReadUInt64(string section, string name, ulong? defaultValue = null);

        /// <summary>Reads a float value.</summary>
        /// <param name="section">The section.</param>
        /// <param name="name">The name.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <exception cref="ArgumentException">If no default value is specified an ArgumentException will be thrown.</exception>
        /// <returns>Returns the (converted) value if a value is present or the default value if not.</returns>
        float ReadFloat(string section, string name, float? defaultValue = null);

        /// <summary>Reads a double value.</summary>
        /// <param name="section">The section.</param>
        /// <param name="name">The name.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <exception cref="ArgumentException">If no default value is specified an ArgumentException will be thrown.</exception>
        /// <returns>Returns the (converted) value if a value is present or the default value if not.</returns>
        double ReadDouble(string section, string name, double? defaultValue = null);

        /// <summary>Reads a decimal value.</summary>
        /// <param name="section">The section.</param>
        /// <param name="name">The name.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <exception cref="ArgumentException">If no default value is specified an ArgumentException will be thrown.</exception>
        /// <returns>Returns the (converted) value if a value is present or the default value if not.</returns>
        decimal ReadDecimal(string section, string name, decimal? defaultValue = null);

        /// <summary>Reads a time span value.</summary>
        /// <param name="section">The section.</param>
        /// <param name="name">The name.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <exception cref="ArgumentException">If no default value is specified an ArgumentException will be thrown.</exception>
        /// <returns>Returns the (converted) value if a value is present or the default value if not.</returns>
        TimeSpan ReadTimeSpan(string section, string name, TimeSpan? defaultValue = null);

        /// <summary>Reads a date time value.</summary>
        /// <param name="section">The section.</param>
        /// <param name="name">The name.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <exception cref="ArgumentException">If no default value is specified an ArgumentException will be thrown.</exception>
        /// <returns>Returns the (converted) value if a value is present or the default value if not.</returns>
        DateTime ReadDateTime(string section, string name, DateTime? defaultValue = null);

        /// <summary>Reads the enum.</summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <param name="section">The section.</param>
        /// <param name="name">The name.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <exception cref="ArgumentException">If no default value is specified an ArgumentException will be thrown.</exception>
        /// <returns>Returns the (converted) value if a value is present or the default value if not.</returns>
        T ReadEnum<T>(string section, string name, T? defaultValue = null)
            where T : struct, IConvertible;

        #endregion

        #region GetValue Members

        /// <summary>
        /// Directly obtains a value from the specified subsection(s) with the specified name.
        /// </summary>
        /// <param name="section">The subsection(s).</param>
        /// <param name="name">The name of the setting.</param>
        /// <param name="value">The default value.</param>
        /// <returns>Returns true if the setting exist and the read value was returned, true otherwise (default value returned).</returns>
        bool GetValue(string section, string name, ref bool value);

        /// <summary>
        /// Directly obtains a value from the specified subsection(s) with the specified name.
        /// </summary>
        /// <param name="section">The subsection(s).</param>
        /// <param name="name">The name of the setting.</param>
        /// <param name="value">The default value.</param>
        /// <returns>Returns true if the setting exist and the read value was returned, true otherwise (default value returned).</returns>
        bool GetValue(string section, string name, ref string value);

        /// <summary>
        /// Directly obtains a value from the specified subsection(s) with the specified name.
        /// </summary>
        /// <param name="section">The subsection(s).</param>
        /// <param name="name">The name of the setting.</param>
        /// <param name="value">The default value.</param>
        /// <returns>Returns true if the setting exist and the read value was returned, true otherwise (default value returned).</returns>
        bool GetValue(string section, string name, ref int value);

        /// <summary>
        /// Directly obtains a value from the specified subsection(s) with the specified name.
        /// </summary>
        /// <param name="section">The subsection(s).</param>
        /// <param name="name">The name of the setting.</param>
        /// <param name="value">The default value.</param>
        /// <returns>Returns true if the setting exist and the read value was returned, true otherwise (default value returned).</returns>
        bool GetValue(string section, string name, ref uint value);

        /// <summary>
        /// Directly obtains a value from the specified subsection(s) with the specified name.
        /// </summary>
        /// <param name="section">The subsection(s).</param>
        /// <param name="name">The name of the setting.</param>
        /// <param name="value">The default value.</param>
        /// <returns>Returns true if the setting exist and the read value was returned, true otherwise (default value returned).</returns>
        bool GetValue(string section, string name, ref long value);

        /// <summary>
        /// Directly obtains a value from the specified subsection(s) with the specified name.
        /// </summary>
        /// <param name="section">The subsection(s).</param>
        /// <param name="name">The name of the setting.</param>
        /// <param name="value">The default value.</param>
        /// <returns>Returns true if the setting exist and the read value was returned, true otherwise (default value returned).</returns>
        bool GetValue(string section, string name, ref ulong value);

        /// <summary>
        /// Directly obtains a value from the specified subsection(s) with the specified name.
        /// </summary>
        /// <param name="section">The subsection(s).</param>
        /// <param name="name">The name of the setting.</param>
        /// <param name="value">The default value.</param>
        /// <returns>Returns true if the setting exist and the read value was returned, true otherwise (default value returned).</returns>
        bool GetValue(string section, string name, ref float value);

        /// <summary>
        /// Directly obtains a value from the specified subsection(s) with the specified name.
        /// </summary>
        /// <param name="section">The subsection(s).</param>
        /// <param name="name">The name of the setting.</param>
        /// <param name="value">The default value.</param>
        /// <returns>Returns true if the setting exist and the read value was returned, true otherwise (default value returned).</returns>
        bool GetValue(string section, string name, ref double value);

        /// <summary>
        /// Directly obtains a value from the specified subsection(s) with the specified name.
        /// </summary>
        /// <param name="section">The subsection(s).</param>
        /// <param name="name">The name of the setting.</param>
        /// <param name="value">The default value.</param>
        /// <returns>Returns true if the setting exist and the read value was returned, true otherwise (default value returned).</returns>
        bool GetValue(string section, string name, ref decimal value);

        /// <summary>
        /// Directly obtains a value from the specified subsection(s) with the specified name.
        /// </summary>
        /// <param name="section">The subsection(s).</param>
        /// <param name="name">The name of the setting.</param>
        /// <param name="value">The default value.</param>
        /// <returns>Returns true if the setting exist and the read value was returned, true otherwise (default value returned).</returns>
        bool GetValue(string section, string name, ref DateTime value);

        /// <summary>
        /// Directly obtains a value from the specified subsection(s) with the specified name.
        /// </summary>
        /// <param name="section">The subsection(s).</param>
        /// <param name="name">The name of the setting.</param>
        /// <param name="value">The default value.</param>
        /// <returns>Returns true if the setting exist and the read value was returned, true otherwise (default value returned).</returns>
        bool GetValue(string section, string name, ref TimeSpan value);

        /// <summary>
        /// Directly obtains a (enum) value from the specified subsection(s) with the specified name.
        /// </summary>
        /// <typeparam name="T">Type of the enum.</typeparam>
        /// <param name="section">The subsection(s).</param>
        /// <param name="name">The name of the setting.</param>
        /// <param name="value">The default value.</param>
        /// <returns>Returns true if the setting exist and the read value was returned, true otherwise (default value returned).</returns>
        bool GetEnum<T>(string section, string name, ref T value)
            where T : struct, IConvertible;
        #endregion
    }
}
