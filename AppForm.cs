
//Face detection and recognition
//Using EmguCV cross platform .Net wrapper to the Intel OpenCV image processing library for C#.Net

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Diagnostics;

namespace FaceDetectionAndRecognition{
    public partial class FaceForm : Form{
        //Declararation of all variables, vectors and haarcascades
        Image<Bgr, Byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> imageList = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> names = new List<string>();
        int tfCounter, NumLabels, t;
        string name;

        public FaceForm(){
            InitializeComponent();
            //Load haarcascades for face detection
            face = new HaarCascade("haarcascade_frontalface_default.xml");

            //Initialize the capture device
            grabber = new Capture();
            grabber.QueryFrame();

            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabber);
            btnSaveFace.Enabled = true;

            //Load previous saved faces and labels for each image
            string Labelsinfo = File.ReadAllText(Application.StartupPath + "/SavedFaces/SavedLabels.txt");

            if (Labelsinfo != ""){
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                tfCounter = NumLabels;
                string LoadFaces;

                for (int sf = 1; sf < NumLabels + 1; sf++){
                    LoadFaces = "face" + sf + ".bmp";
                    imageList.Add(new Image<Gray, byte>(Application.StartupPath + "/SavedFaces/" + LoadFaces));
                    labels.Add(Labels[sf]);
                }
            }
        }

        private void btnSaveFace_Click(object sender, System.EventArgs e){
            try{
                //Trained face counter
                tfCounter = tfCounter + 1;

                //Get a gray frame from capture device
                gray = grabber.QueryGrayFrame().Resize(397, 310, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                //Face Detector
                MCvAvgComp[][] detectedFaces = gray.DetectHaarCascade(face, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));

                //Action for each element detected
                foreach (MCvAvgComp m in detectedFaces[0]){
                    TrainedFace = currentFrame.Copy(m.rect).Convert<Gray, byte>();
                    break;
                }

                //resize face detected image for force to compare the same size with the test image with cubic interpolation type method
                TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                imageList.Add(TrainedFace);
                labels.Add(txtName.Text);

                //Write the number of triained faces in a file text for further load
                File.WriteAllText(Application.StartupPath + "/SavedFaces/SavedLabels.txt", imageList.ToArray().Length.ToString() + "%");

                //Write the labels of triained faces in a file text for further load
                for (int i = 1; i < imageList.ToArray().Length + 1; i++){
                    imageList.ToArray()[i - 1].Save(Application.StartupPath + "/SavedFaces/face" + i + ".bmp");
                    File.AppendAllText(Application.StartupPath + "/SavedFaces/SavedLabels.txt", labels.ToArray()[i - 1] + "%");
                }
                MessageBox.Show("Face saved as " + "'" + txtName.Text + "'", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch{
                MessageBox.Show("Please detect your face first!", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void FrameGrabber(object sender, EventArgs e){
            names.Add("");

            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(397, 310, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert it to Grayscale
            gray = currentFrame.Convert<Gray, Byte>();

            //Face Detector
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(face, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));

            //Action for each element detected
            foreach (MCvAvgComp f in facesDetected[0]){
                t = t + 1;
                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //draw the face detected in the 0th (gray) channel with green color
                currentFrame.Draw(f.rect, new Bgr(Color.Green), 2);

                if (imageList.ToArray().Length != 0){
                    //TermCriteria for face recognition with numbers of trained images like maxIteration
                    MCvTermCriteria termCrit = new MCvTermCriteria(tfCounter, 0.001);
                    
                    //Eigen face recognizer
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(imageList.ToArray(), labels.ToArray(), 2500, ref termCrit);
                    
                    name = recognizer.Recognize(result);

                    //Draw the label for each face detected and recognized
                    currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));
                }

                names[t - 1] = name;
                names.Add("");
            }
                
            t = 0;
            
            //Show the faces processed and recognized
            imgBoxCapturer.Image = currentFrame;
            
            //Clear the list(vector) of names
            names.Clear();
        }
    }
}