#include <iostream>

using namespace std;

/* #1 Menu Program to select options with function calls
string liquor()
{
    return "Liquor Menu";
}

string beer(int bottles)
{
    string out = "";
    char bot, bot1;
    //#1 For Loop for 99 Bottles of Beer
    for ( int i = bottles; i > 1; i-- )
    {
        bot = i;
        bot1 = i - 1;
        // Need to better convert ints to strings;
        out = out + bot + " bottles of beer on the wall, " + bot +
        " bottles of beer!\nTake one down, pass it around, " +
         bot1 + " bottles of beer on the wall!\n";
    }
    return out;
}

int main()
{
    string menu = "Menu:\t1) Liquor \t2) Beer \t3) Calculator\n";
    string choice = "0";
    int x = 0;
    string output;
    cout << menu;
    cout << "Enter your choice: ";
    getline(cin, choice, '\n');
    if (choice == "1" || choice == "1)")
    {
        output = liquor();
        cout << output;
    }
    else if (choice == "2" || choice == "2)")
    {   cout << "How many bottles? ";
        cin >> x;
        output = beer(x);
        cout << output;
    }
    else if (choice == "3" || choice == "3)")
        cout << "Wine Menu";
    else
        cout << "Please choose an item on the Menu.\n" << menu;
}
*/
// #2 Calculator Program with Functions
int add(int num1, int num2)
{
    return num1 + num2;
}

int subtract(int num1, int num2)
{
    return num1 - num2;
}

int multiply(int num1, int num2)
{
    return num1*num2;
}

double divide(int num1, int num2)
{
    return num1/num2;
}

int main()
{
    char op;
    float arg1, arg2, soln;
    cout << "Enter the operation +, -, * or /: ";
    cin >> op;
    cout << "Enter argument 1: ";
    cin >> arg1;
    cout << "Enter argument 2: ";
    cin >> arg2;
    if (op == '+')
        soln = add(arg1,arg2);
    else if (op == '-')
        soln = subtract(arg1,arg2);
    else if (op == '*')
        soln = multiply(arg1,arg2);
    else if (op == '/')
        soln = divide(arg1,arg2);
    else
    {
        cout << "Please enter a valid operation next time.";
    }

    cout << soln;
}
//

/* #3 Password prompt with fixed number of tries
bool passwordcheck(string password)
{
    if (password == "abcde")
        {
            return true;
        }
    else
        return false;
}

int main()
{
    int i = 0;
    string pword;
    bool pcheck;
    while (i < 5)
    {
        cout << "Enter password: ";
        cin >> pword;
        pcheck = passwordcheck(pword);
        if (pcheck == true)
        {
            cout << "Correct!";
            break;
        }
        i++;
    }

    if (i >= 5)
        cout << "Number of attempts exceeded hacker!!";
}
*/ //End section
