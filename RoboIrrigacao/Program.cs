using System;


namespace RoboIrrigacao
{
    class Program
    {
 

        static void Main(string[] args)

        {
            int[] TamanhoHorta = ReceberTamanhoHorta();
            int[] Posicao = ReceberPosicaoRobo();
            char Direcao= ReceberDirecaoRobo();
            ValidarRobo(TamanhoHorta, Posicao, Direcao);
            do
            {
                int[] Canteiro = ReceberCanteiroIrrigacao();
                ValidarCanteiro(TamanhoHorta, Canteiro);

                GerarCaminhoIrrigacao(Canteiro[0], Canteiro[1], Direcao, Posicao[0], Posicao[1]);
                Console.WriteLine("Deseja verificar mais um canteiro?\n");

                Console.WriteLine("Enter:Sim Esc:Nao\n");

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            


        }


        private static void GerarCaminhoIrrigacao(int canteiro_x, int canteiro_y, char Direcao,int PosicaoRoboX,int PosicaoRoboY) {
           
            string movimentos = "";
            try {
                switch (Direcao)
                {
                    case 'N':
                        if (PosicaoRoboX < canteiro_x)
                        {
                            movimentos = movimentos + "D";
                            Direcao = 'L';
                        }
                        else
                        {
                            movimentos = movimentos + "E";
                            Direcao = 'O';
                        }
                        break;
                    case 'S':
                        if (PosicaoRoboX < canteiro_x)
                        {
                            movimentos = movimentos + "E";
                            Direcao = 'L';
                        }
                        else
                        {
                            movimentos = movimentos + "D";
                            Direcao = 'O';
                        }
                        break;
                    case 'L':
                        if (PosicaoRoboX > canteiro_x)
                        {
                            movimentos = movimentos + "D" + "D";
                            Direcao = 'O';
                        }
                        break;
                    case 'O':
                        if (PosicaoRoboX < canteiro_x)
                        {
                            movimentos = movimentos + "D" + "D";
                            Direcao = 'L';
                        }
                        break;
                }

                switch (Direcao)
                {
                    case 'L':
                        while (PosicaoRoboX != canteiro_x)
                        {
                            movimentos = movimentos + "M";
                            PosicaoRoboX++;
                        }
                        if (PosicaoRoboY < canteiro_y)
                        {
                            movimentos = movimentos + "E";
                            Direcao = 'N';
                        }
                        else
                        {
                            movimentos = movimentos + "D";
                            Direcao = 'S';
                        }
                        break;
                    case 'O':
                        while (PosicaoRoboX != canteiro_x)
                        {
                            movimentos = movimentos + "M";
                            PosicaoRoboX--;
                        }
                        if (PosicaoRoboY < canteiro_y)
                        {
                            movimentos = movimentos + "D";
                            Direcao = 'N';
                        }
                        else
                        {
                            movimentos = movimentos + "E";
                            Direcao = 'S';
                        }
                        break;
                }

                switch (Direcao)
                {
                    case 'N':
                        while (PosicaoRoboY != canteiro_y)
                        {
                            movimentos = movimentos + "M";
                            PosicaoRoboY++;
                        }
                        movimentos = movimentos + "I";
                        break;
                    case 'S':
                        while (PosicaoRoboY != canteiro_y)
                        {
                            movimentos = movimentos + "M";
                            PosicaoRoboY--;
                        }
                        movimentos = movimentos + "I";
                        break;
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message + "\n");
                Environment.Exit(-1);

            }
            

            Console.WriteLine(movimentos);

        }

        private static void ValidarCanteiro(int[] TamanhoHorta,int[] Canteiro) 
        {
            for (int i = 0; i < TamanhoHorta.Length; i++) {
                if (Canteiro[i] > TamanhoHorta[i])
                {
                    Console.WriteLine("Canteiro fora dos limites da horta");
                    Environment.Exit(-1);

                }


            }
     
        }


        private static void ValidarRobo(int[] TamanhoHorta, int[] PosicaoRobo, char DirecaoRobo) {


            for (int i = 0; i < TamanhoHorta.Length; i++)
            {
                if (PosicaoRobo[i] > TamanhoHorta[i])
                {
                    Console.WriteLine("Robo posicionado fora dos limites da horta");
                    Environment.Exit(-1);

                }
            }
            if (!DirecaoRobo.Equals('N') && !DirecaoRobo.Equals('S') && !DirecaoRobo.Equals('O') && !DirecaoRobo.Equals('L')) {
                Console.WriteLine("Comando inexistente para direcao");
                Environment.Exit(-1);

           }
               
        }

        private static int[] ReceberPosicaoRobo() {
            int[] posicao = new int[2];
            try {
                //pegar posicao robo
               
                Console.WriteLine("Informe a posicao do robo, componente X");
                posicao[0] = int.Parse(Console.ReadLine());
                Console.WriteLine("Informe a posicao do robo, componente Y");
                posicao[1] = int.Parse(Console.ReadLine());
               

            }
            catch (Exception e)
            {
                Console.Write(e.Message + "\n");
                Environment.Exit(-1);

            }

            return posicao;

        }   

        private static int[] ReceberTamanhoHorta()
        {
            int[] resultado = new int[2];
            //pegar tamanho da horta
            try
            {
                Console.WriteLine("Informe o tamanho da area, componente X");

                int horta_x = int.Parse(Console.ReadLine());
                Console.WriteLine("Informe o tamanho da area, componente Y");
                int horta_y = int.Parse(Console.ReadLine());
                resultado[0] = horta_x;
                resultado[1] = horta_y;


            }
            catch(Exception e) {
             Console.Write(e.Message + "\n");
             Environment.Exit(-1);
            }
            return resultado;

        }

        private static char ReceberDirecaoRobo()
        {
            char direcao = ' ';
            try
            {
                //pegar direcao robo
                
                Console.WriteLine("Informe para onde o robo está virado\n");
                Console.WriteLine("N - Norte\n");
                Console.WriteLine("S - Sul\n");
                Console.WriteLine("L - Leste\n");
                Console.WriteLine("O - Oeste\n");
                direcao = char.Parse(Console.ReadLine().ToUpper()) ;
               


            }
            catch (Exception e)
            {
                Console.Write(e.Message+"\n");
                Environment.Exit(-1);
            }

            return direcao;

        }

        private static int[] ReceberCanteiroIrrigacao()
        {
            int[] canteiro = new int[2];
            try {
                
                //pegar posicao robo
                Console.WriteLine("Informe o canteiro a ser irrigado:X\n");
                canteiro[0] = int.Parse(Console.ReadLine());
                Console.WriteLine("Informe o canteiro a ser irrigado:Y\n");
                canteiro[1] = int.Parse(Console.ReadLine());
               
            }
            catch (Exception e)
            {
                Console.Write(e.Message + "\n");
                Environment.Exit(-1);
            }
            return canteiro;

        }

     



    }
}
