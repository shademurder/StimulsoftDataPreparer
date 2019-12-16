using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace StimulsoftDataPreparer
{
    public partial class Form1 : Form
    {
        private List<Data.NodeType> nodeTypes = new List<Data.NodeType>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = "";
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(textBox1.Text);
                List<string> names = new List<string>();
                nodeTypes = new List<Data.NodeType>();
                foreach (XmlNode node in xmlDocument.ChildNodes)
                {
                    names.AddRange(getNodeNames(node, new List<string>(), nodeTypes));

                    
                }
                textBox2.Text += string.Join(Environment.NewLine, names.ToArray());
                int a = 0;
            }
            catch (Exception) { }
        }

        private List<string> getNodeNames(XmlNode node, List<string> names, List<Data.NodeType> nodeTypes)
        {
            if (node.Name != "#text" && !names.Contains(node.Name))
            {
                names.Add(node.Name);
            }
            foreach (XmlNode n in node.ChildNodes)
            {
                names = getNodeNames(n, names, nodeTypes);
            }
            return names;
        }

        private Data.NodeType getExistentNodeType(List<Data.NodeType> nodeTypes, string name)
        {
            foreach(Data.NodeType node in nodeTypes)
            {
                if(node.Name == name)
                {
                    return node;
                }
            }
            return null;
        }
    }
}
