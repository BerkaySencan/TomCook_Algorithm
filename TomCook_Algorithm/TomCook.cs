using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace TomCook_Algorithm
{
    class TomCook
    {

       

       public List<BigInteger> RightSplit(BigInteger x)
            {

            // x Right Spliting
            List<BigInteger> xPieces = new List<BigInteger>();
            if (x.ToString().Length >= 8)
                {

                // Sayının Uzunluğunu Kontrol Etmek için
                    int count = 0;
                // Sondan 8'er Parçaya Ayırmak için
                    int brackets = 8;


                    

                   while ((x.ToString().Length - count) > 0)
                   {
                  
                    xPieces.Add(BigInteger.Parse(x.ToString().Substring(x.ToString().Length - brackets, 8)));
                    
                    brackets += 8;
                    
                    count += 8;

                    // 8 rakamın Altına Düşünce Patlamasın diye Kontrol Yapıyoruz
                    if (x.ToString().Length - count < 8)
                    {if (x.ToString().Length - count == 0) break;//0'a 0 İçin Substring Yapamaz Çünkü.
                        int lastDigits = (x.ToString().Length - count);

                        xPieces.Add(BigInteger.Parse(x.ToString().Substring(0, lastDigits)));
                        break;
                        

                    }

                }
                return xPieces;

            }
            else { System.Windows.Forms.MessageBox.Show("En Az 8 Rakamlı Bir Sayı Giriniz.");}


            return xPieces;
            }


        public List<BigInteger> Evalution(List<BigInteger> x)
        {
            List<BigInteger> evaList = new List<BigInteger>();
            BigInteger SecondStep=0;
            BigInteger ThirdStep = 0;
            BigInteger FourthStep = 0;
            int counter = 0;


            // First Step P(0)=m0 Always
            #region
            evaList.Add(x[0]);
            #endregion
            // Second Step P(1)=m0+m1+m2....         
            #region
            foreach (BigInteger item in x)
            {
                SecondStep += item;
            }
            evaList.Add(SecondStep);
            #endregion
            // Third Step P(-1) =m0-m1+m2-m3+m4.....
            #region
            foreach (BigInteger item in x)
            {
                if (counter%2==0)
                {
                    ThirdStep += item;
                    counter++;
                }
                else
                {
                    ThirdStep -= item;
                    counter++;
                }
            }counter = 0;

            evaList.Add(ThirdStep);
            #endregion
            // Fourth Step P(-2) =m0-2m1+4m2
            #region
            foreach (BigInteger item in x)
            {
                FourthStep += item * Square(-2, counter);
                counter++;
            }

            evaList.Add(FourthStep);
            #endregion
            // Fiveth Step P(∞) =m(last)
            #region
            evaList.Add(x[x.Count - 1]);
            #endregion

            return evaList;


        }

        public List<BigInteger> PointWise(List<BigInteger> x,List<BigInteger> y)


        {
            List<BigInteger> pwList = new List<BigInteger>();
            for (int i = 0; i < x.Count; i++)
            {
                pwList.Add(x[i] * y[i]);
            }
            return pwList;


        }

        public List<BigInteger> Interpolation(List<BigInteger> pwList)
        {

            List<BigInteger> Operations = new List<BigInteger>();
            List<BigInteger> oResult = new List<BigInteger>();
            //r0	←	r(0)
            Operations.Add(pwList[0]);
            //r4	←	r(∞)
            Operations.Add(pwList[4]);
            //r3	←	(r(−2) − r(1))/3
            Operations.Add((pwList[3] - pwList[1]) / 3);
            //r1	←	(r(1) − r(−1))/2
            Operations.Add((pwList[1] - pwList[2]) / 2);
            //r2	←	r(−1) − r(0)
            Operations.Add(pwList[2] - pwList[0]);
            // new r0
            oResult.Add(Operations[0]);
            // new r3 yanlıs  r3	←	(r2 − r3)/2 + 2r(∞)	
            oResult.Add((Operations[4] - Operations[2]) / 2 + 2 * Operations[1]);
            // new  r2	←	r2 + r1 − r4
            oResult.Add(Operations[4] + Operations[3] - Operations[1]);
            // new r1 yanlıs  r1	←	r1 − r3(new)
            oResult.Add(Operations[3] - oResult[1]);
            // new r4
            oResult.Add(Operations[1]);

            
            return oResult;
        }

        public BigInteger Recomposition(List<BigInteger>ipList)
        {
            //8 Basamak kaydırmak için counter 8 ' den başlatıp 8 'erli arttırıyoruz.
            int Counter = 8;
            BigInteger total=0;
            List<BigInteger> addition = new List<BigInteger>();
            addition.Add(ipList[0]);
            addition.Add(PadRightZero(ipList[3], Counter));
            Counter+=8;
            addition.Add(PadRightZero(ipList[2], Counter));
            Counter+=8;
            addition.Add(PadRightZero(ipList[1], Counter));
            Counter+=8;
            addition.Add(PadRightZero(ipList[4], Counter));

            
            foreach (BigInteger item in addition)
            {
                total += item;
            }
            return total;

        }

        public BigInteger PadRightZero(BigInteger x, int Counter)
        {

            // Sayıların Sağına 8 Sıfır Eklemek
            

    
            StringBuilder st = new StringBuilder();
            st.Append(x);
            
            for (int i = 0; i < Counter; i++)
            {

                st.Append(0);
            }
            
            return BigInteger.Parse(st.ToString());

           

        }




        public long Square(int x, int exponent)
        {
            int y=1;
            if (exponent == 0)
            {
                return 1;

            }
            for (int i = 0; i < exponent; i++)
            {
               
                    y = y*x;
 
            }
            
            return y;

        }   
            




        
    }

}

