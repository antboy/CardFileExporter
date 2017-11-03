// CardFileExporter - Copyright © 2016 John Oliver
// This program is free software: you can redistribute it and/or modify it under
// the terms of the GNU General Public License as published by the Free Software
// Foundation, either version 3 of the License, or (at your option) any later
// version.
// This program is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
// FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
// details.
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.IO;
using System.Text;

using CardFileRdr;

namespace CardFileExporter {

	/// <summary>
	/// Write a simple XML file to hold imported Cardfile data
	/// </summary>
	public class XmlWriter : Writer {

		private string filename;
		private StreamWriter XmlFile;

		private const String INDENT1 = "    ";//4 spaces
		private const String INDENT2 = INDENT1 + INDENT1;


		/// <summary>
		/// Construct an object of the class
		/// </summary>
		/// <param name="filename">To where the object should be written</param>
		public XmlWriter( string filename ) {
			if (filename == null) {
				throw new ArgumentNullException( "XmlWriter(): null filename received" );
			}
			this.filename = filename;
		}


		/// <summary>
		/// Write a header, if appropriate
		/// </summary>
		public void WriteHeader() {
			XmlFile = new StreamWriter( filename, true, Encoding.UTF8 ); // true to append

			XmlFile.WriteLine( "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" );
			XmlFile.WriteLine( "<CardFile>" );
			XmlFile.Flush();
		}


		/// <summary>
		/// Write the equivalent of the card - but text only - objects are ignored
		/// </summary>
		/// <param name="card">The card data</param>
		public void WriteCard( Card card ) {
			if (card == null) {
				throw new ArgumentNullException( "XmlWriter.WriteCard(): null card received" );
			}

			if (!(String.IsNullOrEmpty( card.Title )) || !(String.IsNullOrEmpty( card.Data ))) {
				if (XmlFile == null) {
					WriteHeader();
				}
				WriteTitle( card.Title );
				WriteEntry( card.Data );
			}//has data
		}


		/// <summary>
		/// Write the equivalent of the card index title
		/// </summary>
		/// <param name="title">Card index title</param>
		private void WriteTitle( string title ) {
			XmlFile.WriteLine( String.Format( "{0}<Card>", INDENT1 ) );
			XmlFile.Write( String.Format( "{0}<Title>", INDENT2 ) );
			XmlFile.Write( title );
			XmlFile.WriteLine( "</Title>" );
			XmlFile.Flush();
		}


		/// <summary>
		/// Write the equivalent of the card data - but text only - objects are ignored
		/// </summary>
		/// <param name="entry">The card data</param>
		private void WriteEntry( string entry ) {
			XmlFile.Write( String.Format( "{0}<Data>", INDENT2 ) );
			XmlFile.Write( entry );
			XmlFile.WriteLine( "</Data>" );
			XmlFile.WriteLine( String.Format( "{0}</Card>", INDENT1 ) );
			XmlFile.Flush();
		}


		/// <summary>
		/// Close and dispose of the writable object
		/// </summary>
		public void close() {
			if (XmlFile != null) {
				XmlFile.WriteLine( "</CardFile>" );
				XmlFile.Flush();
				XmlFile.Close();
			} else {
				throw new ExnCardFileRdr( "XML file not produced - could not find any text data to export" );
			}
		}
	}//class
}//nm
