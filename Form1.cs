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
using System.Windows.Forms;
using System.IO;

using CardFileRdr;

namespace CardFileExporter {

	/// <summary>
	/// The main form of the application
	/// </summary>
	public partial class Form1: Form {
		private string filename;

		/// <summary>
		/// Construct the form
		/// </summary>
		public Form1() {
			InitializeComponent();
		}


		private void Form1_Load( object sender, EventArgs e ) {
		}


		/// <summary>
		/// The file to be processed
		/// </summary>
		/// <param name="sender">The object triggering the event</param>
		/// <param name="e">The event args</param>
		private void tbFilename_TextChanged( object sender, EventArgs e ) {
			filename = tb_Filename.Text;
		}


		// Run button, read the cardfile & write it out as XML
		private void b_go_Click( object sender, EventArgs e ) {
			string stsMsg = "File " + filename + " had a problem"; // status message
			rtb_Msg.Text = "Export pressed";
			try {
				FileInfo f = new FileInfo(filename); // card file file to read
				string outPath = Path.GetDirectoryName(filename) + Path.DirectorySeparatorChar; // path of file to be read
				string outFileName = Path.GetFileNameWithoutExtension(filename);

				const string xmlext = ".xml";
				string xmlFilePath = outPath + outFileName + xmlext;
				Writer wrtr = new XmlWriter(xmlFilePath); // Destination of Xml produced

				bool doTrace = cbDoLogging.Checked; // Logging?
				const string logext = ".log";
				string logFilePath = outPath + outFileName + logext; ;

				CardFile cf = new CardFile(doTrace, logFilePath, wrtr);
				using (Stream inStrm = f.OpenRead()) {
					cf.process( inStrm );
				}
				rtb_Msg.Text = "File " + xmlFilePath + " produced";

			} catch (ExnCardFileRdr ex) {
				ReportError( ex.Message, "Warning", stsMsg );
			} catch (Exception ex) when (ex is FileNotFoundException || ex is DirectoryNotFoundException) {
				ReportError( ex.Message, "Warning", stsMsg );
			} catch (Exception ex) {
				ReportError( ex.ToString(), "Error", stsMsg );
			}//try
		}//b_go


		// Show error text & set status field
		private void ReportError(string msg, string errType, string sMsg) {
			MessageBox.Show( msg,
				errType,
				MessageBoxButtons.OK,
				MessageBoxIcon.Exclamation,
				MessageBoxDefaultButton.Button1 );
			rtb_Msg.Text = sMsg;
		}


		// Open file browser dialogue
		private void b_Browse_Click( object sender, EventArgs e ) {
			String filePath;
			if (openFileDialog1.ShowDialog() == DialogResult.OK) {
				filePath = openFileDialog1.FileName;
				tb_Filename.Text = filePath;
			}
		}

	}//class
}//nm
