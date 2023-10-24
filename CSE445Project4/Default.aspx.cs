using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace CSE445Project4
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            outputPanel.Visible = false;
        }
        string str = "";

        protected void ParkBtn_Click(object sender, EventArgs e)
        {
            string xmlFilePath = Server.MapPath("~/Parks.xml");
            urlInput.Text = xmlFilePath;
            submitBtn_Click(sender, e);
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string url = urlInput.Text;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(url);
            XmlNode root1 = xmlDoc.DocumentElement;
            XmlNode root2 = xmlDoc.DocumentElement;

            str = "";
            preOrder(root1);
            preText.Text = str;

            str = "";
            postOrder(root2);
            postText.Text = str;

            outputPanel.Visible = true;
        }

        void preOrder(XmlNode xmlNode)
        {
            if (xmlNode == null)
            {
                System.Environment.Exit(1);
            }

            //  Styling flexibility
            str += "<div>";

            // If the node is "Park", include header to specify a park
            if (xmlNode.Name == "Park")
            {
                str += "<h4>Park:</h4>";
            }

            // Display  node details
            str += "Node Type: " + xmlNode.NodeType + " | Node Name: " + xmlNode.Name;

            // Add node if it's not null or whitespace
            if (!string.IsNullOrWhiteSpace(xmlNode.Value))
            {
                str += " | Node Text: " + xmlNode.Value.Trim();
            }

            if (xmlNode.Attributes != null && xmlNode.Attributes.Count > 0)
            {
                str += "<br/><b>Attributes:</b>";
                foreach (XmlAttribute atr in xmlNode.Attributes)
                {
                    str += "<br/> - " + atr.Name + ": " + atr.Value;
                }
            }

            str += "</div>";

            if (xmlNode.HasChildNodes)
            {
                foreach (XmlNode child in xmlNode.ChildNodes)
                {
                    preOrder(child);
                }
            }
        }

        void postOrder(XmlNode node)
        {
            if (node == null)
            {
                System.Environment.Exit(1);
            }

            if (node.HasChildNodes)
            {
                XmlNodeList children = node.ChildNodes;
                foreach (XmlNode child in children)
                {
                    postOrder(child);
                }
            }

            // Styling flexibility
            str += "<div>";

            // If the node is "Park", include header to specify a park
            if (node.Name == "Park")
            {
                str += "<h4>Park:</h4>";
            }

            // Display node details
            str += "Node Type: " + node.NodeType + " | Node Name: " + node.Name;

            // Add if it's not null or whitespace
            if (!string.IsNullOrWhiteSpace(node.Value))
            {
                str += " | Node Text: " + node.Value.Trim();
            }

            if (node.Attributes != null && node.Attributes.Count > 0)
            {
                str += "<br/><b>Attributes:</b>";
                foreach (XmlAttribute atr in node.Attributes)
                {
                    str += "<br/> - " + atr.Name + ": " + atr.Value;
                }
            }

            str += "</div>";
        }
    }
}