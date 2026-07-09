/*
Copyright (C) 2016 by Eric Bataille <e.c.p.bataille@gmail.com>

Modified for KiBoard
Copyright (C) 2026 kiwicore

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

namespace ThoNohT.NohBoard.Extra
{
    using System.Drawing;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents a color, stored in a way that it can be serialized.
    /// </summary>
    [DataContract(Name = "Color", Namespace = "")]
    public class SerializableColor
    {
        /// <summary>
        /// The alpha component.
        /// </summary>
        [DataMember]
        public byte Alpha { get; set; }

        /// <summary>
        /// The red component.
        /// </summary>
        [DataMember]
        public byte Red { get; set; }

        /// <summary>
        /// The green component.
        /// </summary>
        [DataMember]
        public byte Green { get; set; }

        /// <summary>
        /// The blue component.
        /// </summary>
        [DataMember]
        public byte Blue { get; set; }

        /// <summary>
        /// Converts a <see cref="SerializableColor"/> to a <see cref="Color"/>.
        /// </summary>
        /// <param name="src">The color to convert.</param>
        public static implicit operator Color(SerializableColor src)
        {
            return Color.FromArgb(src.Alpha, src.Red, src.Green, src.Blue);
        }

        /// <summary>
        /// Converts a <see cref="Color"/> to a <see cref="SerializableColor"/>.
        /// </summary>
        /// <param name="src">The color to convert.</param>
        public static implicit operator SerializableColor(Color src)
        {
            return new SerializableColor
            {
                Alpha = src.A,
                Red = src.R,
                Green = src.G,
                Blue = src.B
            };
        }

        /// <summary>
        /// Creates a clone of this serializable color.
        /// </summary>
        /// <returns>The cloned color.</returns>
        public SerializableColor Clone()
        {
            return (SerializableColor)this.MemberwiseClone();
        }

        /// <summary>
        /// Checks if this color has changes relative with the specified other color.
        /// </summary>
        /// <param name="other">The color to compare against.</param>
        /// <returns>True if the color has changes, false otherwise.</returns>
        public bool IsChanged(SerializableColor other)
        {
            return this.Alpha != other.Alpha || this.Red != other.Red || this.Green != other.Green || this.Blue != other.Blue;
        }
    }

}