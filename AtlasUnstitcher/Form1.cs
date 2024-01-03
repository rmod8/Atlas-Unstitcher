using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AtlasUnstitcher
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Stores the image selected, used to generate the preview and final export images.
        /// </summary>
        private Bitmap BaseImage;
        public Form1()
        {
            InitializeComponent();

            // Prevent the user from screwing up the settings to cause crashes
            if(Properties.Settings.Default.selectedBackground < 0 || Properties.Settings.Default.selectedBackground > 3)
            {
                Properties.Settings.Default.selectedBackground = 0;
                Properties.Settings.Default.Save();
            }
            comboBackType.SelectedIndex = Properties.Settings.Default.selectedBackground;

            // Don't load the Minecraft Suffix
            if (Properties.Settings.Default.selectedBackground < 0 || Properties.Settings.Default.selectedBackground > 3 || Properties.Settings.Default.selectedBackground == 3)
            {
                Properties.Settings.Default.selectedSuffix = 1;
                Properties.Settings.Default.Save();
            }
            comboSuffix.SelectedIndex = Properties.Settings.Default.selectedSuffix;


            // Change Preview Background after we load the user's preference.
            ChangePreviewBackground(comboBackType.SelectedIndex);
        }

        /// <summary>
        /// Prompts the user to open an image file to load into the application. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolstripMenuOpen_Click(object sender, EventArgs e)
        {

            // Set up OpenFileDialog with the filters we want.
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.CheckFileExists = true;
            ofd.Filter = "Image Files(*.PNG;*.JPG;*.JPEG;*.GIF;*.BMP)|*.PNG;*.JPG;*.JPEG;*.GIF;*.BMP";

            // Return if the user didn't select an image
            if (ofd.ShowDialog() != DialogResult.OK) return;

            BaseImage = new Bitmap(ofd.FileName);
            textbExportedName.Text = Path.GetFileNameWithoutExtension(ofd.SafeFileName);
            
            /*
             * Turns out we don't need to do this at all, I was just dumb.
            // Check if the image is valid...
            if(BaseImage.Width % 2 != 0 || BaseImage.Height % 2 != 0)
            {
                MessageBox.Show("The selected image need to be divisble by 2!\nExample: 10x16", "Image resolution is odd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            */

            ofd.Dispose();
            buttonExport.Enabled = true;
            NumericX.Enabled = true;
            NumericY.Enabled = true;
            comboSuffix.Enabled = true;
            textbExportedName.Enabled = true;

            /*
             * Time to calculate the image's aspect ratio for labelAspectRatio.
             * We recursivley modulo X with Y, or Y with X until we reach the resolutions greatest common divisor.
            */
            int imageXAccum = BaseImage.Width;
            int imageYAccum = BaseImage.Height;
            int GCD = 0;
            if(imageXAccum > imageYAccum)
            {
                while (imageYAccum != 0)
                {
                    int temp = imageYAccum;
                    imageYAccum = imageXAccum % imageYAccum;
                    imageXAccum = temp;
                }
                GCD = imageXAccum;
            }
            else
            {
                while (imageXAccum != 0)
                {
                    int temp = imageXAccum;
                    imageXAccum = imageYAccum % imageXAccum;
                    imageYAccum = temp;
                }
                GCD = imageYAccum;
            }

            labelAspectRatio.Text = (int)BaseImage.Width/GCD+" : "+ (int)BaseImage.Height / GCD;
            NumericX.Value = (decimal)(int)BaseImage.Width / GCD;
            NumericY.Value = (decimal)(int)BaseImage.Height / GCD;
            UpdatePreview();
        }

        /// <summary>
        /// Updates PictureBox preview if the user updates the SectorX or SectorY NumericUpDowns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Numeric_ValueChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        /// <summary>
        /// Prompts the user where to export the final images to.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExport_Click(object sender, EventArgs e)
        {
            // Check to see if the images can be exported in this format
            if((BaseImage.Width / NumericX.Value) % 1 !=0 || (BaseImage.Height / NumericY.Value) % 1 != 0)
            {
                MessageBox.Show("The current configuration of the sectors are invalid" +
                    "\nwith the original image's resolution!\n\nTry using an equal number!", "Sectors not setup correctly!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "[Folder Selection]";
            saveFileDialog.Title = "Select a folder to export to:";
            saveFileDialog.Filter = "All Files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            this.Enabled = false;
            string savePath = Path.GetDirectoryName(saveFileDialog.FileName) + @"\";
            int outputX = (int)BaseImage.Width / (int)NumericX.Value;
            int outputY = (int)BaseImage.Height / (int)NumericY.Value;
            saveFileDialog.Dispose();


            for(int i = 0; i < NumericX.Value * NumericY.Value; i++)
            {
                int x = (i % (int)NumericX.Value) * outputX;
                int y = ((i / (int)NumericX.Value) % (int)NumericY.Value) * outputY;
                ReturnImageSection(x, y, outputX, outputY).Save(savePath + GenerateExportName(textbExportedName.Text, comboSuffix.SelectedIndex, i)+".png", System.Drawing.Imaging.ImageFormat.Png);
            }
            this.Enabled = true;
        }

        /// <summary>
        /// Updates the PictureBox preview.
        /// </summary>
        private void UpdatePreview()
        {
            if (pictureBox.Image != null)
                pictureBox.Image.Dispose();
            pictureBox.Image = ReturnImageSection(0, 0, BaseImage.Width / (int)NumericX.Value, BaseImage.Height / (int)NumericY.Value);
        }

        /// <summary>
        /// Returns a section of BaseImage in accordance to the parameters provided.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private Image ReturnImageSection(int x, int y, int width, int height)
        {
            if (width == 0)
                width = 1;
            if (height == 0)
                height = 1;

            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(BaseImage, new Rectangle(0, 0, width, height), new Rectangle(x, y, width, height), GraphicsUnit.Pixel);
            g.Dispose();
            return bmp;
        }

        private void ChangePreviewBackground(int Index)
        {
            switch (Index)
            {
                case 0:
                    pictureBox.BackgroundImage = null;
                    pictureBox.BackColor = Color.White;
                    break;
                case 1:
                    pictureBox.BackgroundImage = null;
                    pictureBox.BackColor = Color.Magenta;
                    break;
                case 2:
                    pictureBox.BackgroundImage = Properties.Resources.MissingTexture;
                    break;
                case 3:
                    pictureBox.BackgroundImage = Properties.Resources.MissingTextureMagenta;
                    break;
            }
        }

        private void comboBackType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.selectedBackground = comboBackType.SelectedIndex;
            Properties.Settings.Default.Save();
            ChangePreviewBackground(comboBackType.SelectedIndex);
        }

        private void textbExportedName_TextChanged(object sender, EventArgs e)
        {
            labelExampleExportName.Text = GenerateExportName(textbExportedName.Text, comboSuffix.SelectedIndex, 0);
        }

        /// <summary>
        /// Generates the export name for each file, depending on the inputted parameters.
        /// </summary>
        /// <param name="basename"></param>
        /// <param name="suffix"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private string GenerateExportName(string basename, int suffix, int count)
        {
            // We could just grab the suffix from the suffix combo box but I did it like this for some reason.
            switch(suffix)
            {
                // Increment
                case 0:
                    return basename + "_"+count;

                // Axis Increment XY and YX
                case 1:
                case 2:
                    // Modulo the count variable to find the remainder. So if NumericX is 16 and count is 17, x will be 1
                    int x = count % (int)NumericX.Value;
                    // I honestly don't know how to explain this sorry.
                    int y = (count/ (int)NumericX.Value) % (int)NumericY.Value;

                    if(suffix == 1)
                    return basename + "_x"+ x + "_y"+y;
                    else
                        return basename + "_y" + y + "_x" + x;

                // Returns Minecraft Name
                case 3:
                    return MinecraftTerrainImageNames[count];


                default:
                    return basename;
            }
        }

        /// <summary>
        /// Saves the user's selected Suffix, and also sets up NumericX and NumericY for Minecraft's
        /// Suffix if it's selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboSuffix_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboSuffix.SelectedIndex == 3)
            {
                toolstripMenuOpen.Enabled = false;
                NumericX.Value = 16;
                NumericY.Value = 16;
                NumericX.Enabled = false;
                NumericY.Enabled = false;
            }
            else
            {
                toolstripMenuOpen.Enabled = true;
                NumericX.Enabled = true;
                NumericY.Enabled = true;
            }
            labelExampleExportName.Text = GenerateExportName(textbExportedName.Text, comboSuffix.SelectedIndex, 0);
            Properties.Settings.Default.selectedSuffix = comboSuffix.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// String Array which stores the names for Minecraft blocks in 'terrain.png'
        /// </summary>
        private static string[] MinecraftTerrainImageNames = { 
            "grass_block_top",
            "stone",
            "dirt",
            "grass_block_side",
            "oak_planks",
            "smooth_stone_slab_side",
            "smooth_stone",
            "bricks",
            "tnt_side",
            "tnt_top",
            "tnt_bottom",
            "cobweb",
            "rose",
            "dandelion",
            "water",
            "oak_sapling",
            "cobblestone",
            "bedrock",
            "sand",
            "gravel",
            "oak_log",
            "oak_log_top",
            "iron_block",
            "gold_block",
            "diamond_block",
            "emerald_block",
            "unused",
            "unused",
            "red_mushroom",
            "brown_mushroom",
            "jungle_sapling",
            "unused",
            "gold_ore",
            "iron_ore",
            "coal_ore",
            "bookshelf",
            "mossy_cobblestone",
            "obsidian",
            "grass_block_side_overlay",
            "grass",
            "unused",
            "beacon",
            "unused",
            "crafting_table_top",
            "furnace_front",
            "furnace_side",
            "dispenser_front",
            "unused",
            "sponge",
            "glass",
            "diamond_ore",
            "redstone_ore",
            "oak_leaves",
            "oak_leaves_opaque",
            "stone_bricks",
            "dead_bush",
            "fern",
            "unused",
            "unused",
            "crafting_table_side",
            "crafting_table_front",
            "furnace_front_on",
            "furnace_top",
            "spruce_sapling",
            "white_wool",
            "spawner",
            "snow",
            "ice",
            "grass_block_snow",
            "cactus_top",
            "cactus_side",
            "cactus_bottom",
            "clay",
            "sugar_cane",
            "jukebox_side",
            "jukebox_top",
            "lily_pad",
            "mycelium_side",
            "mycelium_top",
            "birch_sapling",
            "torch",
            "oak_door_top",
            "iron_door_top",
            "ladder",
            "oak_trapdoor",
            "iron_bars",
            "farmland_moist",
            "farmland",
            "wheat_stage0",
            "wheat_stage1",
            "wheat_stage2",
            "wheat_stage3",
            "wheat_stage4",
            "wheat_stage5",
            "wheat_stage6",
            "wheat_stage7",
            "lever",
            "oak_door_bottom",
            "iron_door_bottom",
            "redstone_torch",
            "mossy_stone_bricks",
            "cracked_stone_bricks",
            "pumpkin_top",
            "netherrack",
            "soul_sand",
            "glowstone",
            "piston_top_sticky",
            "piston_top",
            "piston_side",
            "piston_bottom",
            "piston_inner",
            "melon_stem",
            "rail_corner",
            "black_wool",
            "gray_wool",
            "redstone_torch_off",
            "spruce_log",
            "birch_log",
            "pumpkin_side",
            "carved_pumpkin",
            "jack_o_lantern",
            "cake_top",
            "cake_side",
            "cake_inner",
            "cake_bottom",
            "red_mushroom_block",
            "brown_mushroom_block",
            "melon_stem_connected",
            "rail",
            "red_wool",
            "pink_wool",
            "repeater",
            "spruce_leaves",
            "spruce_leaves_opaque",
            "bed_top_bottom",
            "bed_top_top",
            "melon_side",
            "melon_top",
            "cauldron_top",
            "cauldron_inner",
            "unused",
            "mushroom_stem",
            "mushroom_block_inside",
            "vine",
            "lapis_block",
            "green_wool",
            "lime_wool",
            "repeater_on",
            "glass_pane_top",
            "bed_side_back",
            "bed_side_bottom",
            "bed_side_top",
            "bed_side_front",
            "jungle_log",
            "cauldron_side",
            "cauldron_bottom",
            "brewing_stand_base",
            "brewing_stand",
            "end_portal_frame_top",
            "end_portal_frame_side",
            "lapis_ore",
            "brown_wool",
            "yellow_wool",
            "powered_rail",
            "redstone_dust_dot",
            "redstone_dust_line",
            "enchanting_table_top",
            "dragon_egg",
            "cocoa_stage2",
            "cocoa_stage1",
            "cocoa_stage0",
            "emerald_ore",
            "tripwire_hook",
            "tripwire",
            "end_portal_frame_eye",
            "end_stone",
            "sandstone_top",
            "blue_wool",
            "light_blue_wool",
            "powered_rail_on",
            "unused",
            "unused",
            "enchanting_table_side",
            "enchanting_table_bottom",
            "command_block_front",
            "item_frame",
            "flower_pot",
            "unused",
            "unused",
            "unused",
            "unused",
            "unused",
            "sandstone",
            "purple_wool",
            "pink_wool",
            "detector_rail",
            "jungle_leaves",
            "jungle_leaves_opaque",
            "spruce_planks",
            "jungle_planks",
            "carrots_stage0",
            "carrots_stage1",
            "carrots_stage2",
            "carrots_stage3",
            "unused",
            "unused",
            "unused",
            "unused",
            "sandstone_bottom",
            "cyan_wool",
            "orange_wool",
            "redstone_lamp",
            "redstone_lamp_on",
            "chiseled_stone_bricks",
            "birch_planks",
            "anvil",
            "chipped_anvil_top",
            "unused",
            "unused",
            "unused",
            "unused",
            "unused",
            "unused",
            "unused",
            "nether_bricks",
            "light_gray_wool",
            "nether_wart_stage0",
            "nether_wart_stage1",
            "nether_wart_stage2",
            "chiseled_sandstone",
            "cut_sandstone",
            "anvil_top",
            "damaged_anvil_top",
            "unused",
            "unused",
            "unused",
            "unused",
            "unused",
            "unused",
            "unused",
            "unused",
            "unused",
            "unused",
            "unused",
            "unused",
            "unused",
            "unused",
            "unused",
            "unused",
            "unused",
            "unused",
            "unused",
            "unused",
            "unused",
            "unused",
            "unused",
        };

    }
}
