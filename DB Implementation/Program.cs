using DB_Implementation;

class DBImpl
{
    static void Main(string[] args)
    {
        DAL dAL = new DAL();

        while (true)
        {
            Console.WriteLine("Select choice:\n 1.Save emp \n 2.List of Employees \n 3.Delete Emp \n 4.Update Emp \n 5.Search \n 6.Exits");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                dAL.saveEmp();
            }
            if (choice == 2)
            {
                dAL.fetchEmp();
            }
            if (choice == 3)
            {
                dAL.DeleteEmp();
            }
            if (choice == 4)
            {
                dAL.updateEmp();
            }
            if (choice == 5)
            {
                dAL.search();
            }
            if (choice == 6)
            {
                break;
            }
        }
    }
}