#include <iostream>
#include <string>

using namespace std;

int main()
{
    /* #1 For Loop for 99 Bottles of Beer
    for ( int i = 99; i > 1; i-- )
    {
        cout << i << " bottles of beer on the wall, " << i <<
        " bottles of beer!\n";
        cout << "Take one down, pass it around, " << i - 1 <<
        " bottles of beer on the wall!\n";
    }
    */

    /* #2 Menu Program to select options
    string menu = "Menu:\t1) Beer \t2) Liquor \t3) Wine \t4) Boring\n";
    string choice = "0";
    cout << menu;
    cout << "Enter your choice: ";
    getline(cin, choice, '\n');
    if (choice == "1" || choice == "1)")
        cout << "Beer Menu";
    else if (choice == "2" || choice == "2)")
        cout << "Liquor Menu";
    else if (choice == "3" || choice == "3)")
        cout << "Wine Menu";
    else if (choice == "4" || choice == "4)")
        cout << "You need to leave.";
    else
        cout << "Please choose an item on the Menu.\n" << menu;
    */

    /* #3 Compute running sum of inputs from user
    double i;
    double sum = 0;
    do
    {
        cout << "Enter a number to be added: ";
        cin >> i;
        sum = sum + i;
        cout << "New sum is: " << sum << endl;
    } while (i != 0);
    cout << "Entering 0 kills the code!";
    */

    /* #4 Password prompt with fixed number of tries
    int i = 0;
    string pword;
    while (i < 5)
    {
        cout << "Enter password: ";
        cin >> pword;
        if (pword == "abcde")
        {
            cout << "Correct!";
            break;
        }
        i++;
    }

    if (i >= 5)
        cout << "Number of attempts exceeded hacker!!";
    */
    /* #6 Display first twenty numbers
    for (int i = 1; i <= 20; i++)
        cout << i * i << endl;
    */

    // #7 Tally up results of poll with 3 possible values
    int choice;
    int one = 0;
    int two = 0;
    int three = 0;
    //int sum;
    while (choice != 0)
    {
        cout << "Enter choice 1) Coke 2) Pepsi 3) Sprite\n";
        cin >> choice;
        if (choice == 1)
            one++;
        else if (choice == 2)
            two++;
        else if (choice == 3)
            three++;
        else
            cout << "Please enter 1, 2 or 3";
    }
    //sum = one + two + three;
    cout << "\n1) ";
    for (int i = 1; i < one; i++)
    {
        cout << "=";
    }
    cout << "\n2) ";
    for (int j = 1; j < two; j++)
    {
        cout << "=";
    }
    cout << "\n3) ";
    for (int k = 1; k < three; k++)
    {
        cout << "=";
    }
}
