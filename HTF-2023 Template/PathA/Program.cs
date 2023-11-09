namespace PathA
{
    public class Program
    {
        private readonly A1 a1;
        private readonly A2 a2;

        public Program()
        {
            a1 = new A1();
            a2 = new A2();
        }

        static async Task Main(string[] args)
        {
            var program = new Program();
            //await program.a1.GetStart();
            //await program.a1.GetPostSample();
            //await program.a1.GetPostPuzzle();
            await program.a2.GetStart();
            await program.a2.GetPostSample();
            await program.a2.GetPostPuzzle();
        }
    }
}