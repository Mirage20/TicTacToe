using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TicTacToe
{
    class BinarySerializeProvider
    {
        public static string FilePath { get; set; }
        public static void save(PlayerStatus settingsObj)
        {

            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(FilePath, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, settingsObj);
                stream.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(null,"Error while saving player data.","TicTacToe",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public static PlayerStatus load()
        {
            
            try
            {
                if (File.Exists(FilePath))
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    PlayerStatus moodleObj;
                    try
                    {
                        moodleObj = (PlayerStatus)formatter.Deserialize(stream);
                       stream.Close();
                    }
                    catch (Exception)
                    {
                        stream.Close();
                        File.Delete(FilePath);
                        moodleObj= load();
                        
                    }
                    
                    
                    return moodleObj;
                }
                else
                {
                    PlayerStatus tmp = PlayerStatus.getInstance();
                    save(tmp);
                    return load();
                }
            }
            catch (Exception)
            {
                
                
            }
            return PlayerStatus.getInstance() ;
        }

        
    }
}
