using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PDF_Splitter
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSplit_Click(object sender, EventArgs e)
        {
           if (fileUpload.HasFile)
            {
                try
                {
                    // Get the uploaded file
                    HttpPostedFile uploadedFile = fileUpload.PostedFile;
                    string fileName = Path.GetFileName(uploadedFile.FileName);
                    string filePath = Server.MapPath("~/Uploads/") + fileName;

                    // Save the uploaded file to the server
                    uploadedFile.SaveAs(filePath);

                    // Get the split range from the textbox
                    string splitRange = txtSplitRange.Text.Trim();

                    // Parse the split range input
                    string[] rangeParts = splitRange.Split('-');
                    if (rangeParts.Length != 2)
                    {
                        ShowPopup("Invalid split range format. Please enter a valid range (e.g., 2-4).");
                        return;
                    }

                    int startPage, endPage;
                    if (!int.TryParse(rangeParts[0], out startPage) || !int.TryParse(rangeParts[1], out endPage))
                    {
                        ShowPopup("Invalid split range format. Please enter a valid range (e.g., 2-4).");
                        return;
                    }

                    // Create a reader to open the PDF
                    PdfReader reader = new PdfReader(filePath);

                    // Validate the split range
                    int totalPages = reader.NumberOfPages;
                    if (startPage < 1 || endPage > totalPages || startPage > endPage)
                    {
                        ShowPopup("Invalid split range. Please enter a valid range within the PDF page count.");
                        reader.Close();
                        return;
                    }

                    // Create a new document to store the combined pages
                    Document document = new Document();
                    string outputFileName = "SplittedFile.pdf";
                    string outputFolderPath = Server.MapPath("~/Output/");
                    string outputFilePath = Path.Combine(outputFolderPath, outputFileName);

                    // Delete the file if it already exists
                    if (File.Exists(outputFilePath))
                    {
                        File.Delete(outputFilePath);
                    }

                    PdfCopy copy = new PdfCopy(document, new FileStream(outputFilePath, FileMode.Create));
                    document.Open();

                    // Copy the specified range of pages to the new document
                    for (int i = startPage; i <= endPage; i++)
                    {
                        copy.AddPage(copy.GetImportedPage(reader, i));
                    }

                    // Close the new document
                    document.Close();

                    // Close the PDF reader
                    reader.Close();

                    // Show the download button
                    btnDownload.Visible = true;
                    ViewState["OutputFilePath"] = outputFilePath; // Store the file path in ViewState
                    ShowPopup("PDF Split successful!");
                }
                catch (Exception ex)
                {
                    ShowPopup("Error: " + ex.Message);
                }
            }
            else
            {
                ShowPopup("Please select a file to upload.");
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            if (ViewState["OutputFilePath"] != null)
            {
                string outputFilePath = ViewState["OutputFilePath"].ToString();

                if (File.Exists(outputFilePath))
                {
                    // Prepare the file download
                    FileInfo file = new FileInfo(outputFilePath);
                    Response.Clear();
                    Response.ClearHeaders();
                    Response.ClearContent();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.ContentType = "application/pdf";
                    Response.Flush();

                    // Write the file content directly to the response
                    Response.TransmitFile(outputFilePath);

                    // Delete the file from the server after download
                    //File.Delete(outputFilePath);

                    Response.End();
                }

                // Clear the ViewState
                ViewState["OutputFilePath"] = null;
            }
        }

        private void ShowPopup(string message)
        {
            ClientScript.RegisterStartupScript(GetType(), "Popup", "alert('" + message + "');", true);
        }
    }
}