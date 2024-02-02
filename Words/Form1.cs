using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Words
{
    public partial class Form1 : Form
    {
        private ArrayList wordsCollection = new ArrayList();
        private ArrayList concatenatedWords = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Create a label to appear like a textbox
            Label textBoxLabel = new Label();
            textBoxLabel.BorderStyle = BorderStyle.FixedSingle;
            textBoxLabel.BackColor = System.Drawing.Color.White; // Set background color to white
            textBoxLabel.Cursor = Cursors.IBeam;
            textBoxLabel.Dock = DockStyle.Bottom; // Dock the label to the bottom
            textBoxLabel.Font = new System.Drawing.Font("Arial", 10); // Set font size to 10

            // Set other properties like Location, Size, and Text as needed
            textBoxLabel.Location = new System.Drawing.Point(50, 50);
            textBoxLabel.Size = new System.Drawing.Size(200, 50);
            textBoxLabel.Text = "";

            // Add label to the form
            Controls.Add(textBoxLabel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string wordToAdd = textBox1.Text.Trim();

            // Check if the TextBox is not empty
            if (string.IsNullOrEmpty(wordToAdd))
            {
                MessageBox.Show("Please enter a word.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the word has not been entered more than once
            if (wordsCollection.Contains(wordToAdd))
            {
                MessageBox.Show("This word has already been added.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            wordsCollection.Add(wordToAdd);

            MessageBox.Show("Word has been added to the collection.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                // Remove item logic
                string selectedWord = comboBox1.SelectedItem as string;

                // Check if a word has been selected
                if (string.IsNullOrEmpty(selectedWord))
                {
                    MessageBox.Show("Please select a word to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                wordsCollection.Remove(selectedWord);

                MessageBox.Show("Word has been removed from the collection.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Concatenate item logic
                string word1 = comboBox1.SelectedItem as string;
                string word2 = comboBox2.SelectedItem as string;

                // Check if words have been selected from both ComboBox controls
                if (string.IsNullOrEmpty(word1) || string.IsNullOrEmpty(word2))
                {
                    MessageBox.Show("Please select words from both ComboBox controls.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check that different words have been selected
                if (word1.Equals(word2))
                {
                    MessageBox.Show("Please select different words from ComboBox controls.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Concatenate words and add to the collection
                string concatenatedWord = word1 + word2;
                concatenatedWords.Add(concatenatedWord);

                MessageBox.Show($"Words have been concatenated: {concatenatedWord}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Display the concatenated words in the Label control
            UpdateLabel();
        }
            private void UpdateLabel()
            {
                label5.Text = string.Join(", ", concatenatedWords.ToArray());
            }
        }

    }


        