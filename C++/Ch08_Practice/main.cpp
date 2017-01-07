#include <iostream>
#include <cstdlib> // to use srand
#include <ctime> // to use time()
#include <sstream>

using namespace std;

int CompareResults(int a, int b, int c, int au, int bu, int cu)
{
    int res = 0;
    if (a == au)
        res ++;
    if (b == bu)
        res ++;
    if (c == cu)
        res ++;
    return res;
}

int CalcWinnings(int res)
{
    int win;
    //cout << "~*~ Debug ~*~ calc_results = " << res << endl;
    switch(res)
    {
        case 1:
            win = 1;
            //cout << "~*~ Debug ~*~ calc_win = " << win << endl;
            break;
        case 2:
            win = 10;
            break;
        case 3:
            win = 100;
            break;
        default:
            win = 0;
            //cout << "~*~ Debug ~*~ calc_def = " << win << endl;
            break;
    }
    //cout << "~*~ Debug ~*~ calc_ret = " << win << endl;
    return win;
}

int randRange(int low, int high)
{
    //Add 1 to get total # of values in range, then add low
    //to bump lower bound of range up to the low value
    return rand() % (high - low + 1) + low;
}

int main()
{
    // time() returns Unix time = # seconds since 1/1/1970
    srand (time(NULL));
    /*#1 Simulate coin flip
    int flip = 1;
    int res;
    double heads = 0;
    double tails = 0;
    double perc;
    while(flip != 0)
    {
        cout << "Enter 1 to flip a coin: ";
        cin >> flip;
        res = randRange(0,1);
        if (res == 0)
            heads++;
        else if (res == 1)
            tails++;
        perc = 100 * heads / (heads + tails);
        cout << "Result: " << res << endl;
        cout << "Heads: " << heads << "\nTails: " << tails << endl;
        cout << "Percentage Heads: " << perc << "%" << endl;
    }
    */
    /*#2 Program picks 1-100, user guesses, program helps
    int guess;
    int ans = randRange(0,100);

    cout << "I've picked a number between 1 and 100!\n";
    cout << "Enter your guess: ";
    cin >> guess;
    while (guess != ans)
    {
        if (guess > ans)
            cout << "Too high!\n";
        else if (guess < ans)
            cout << "Too low!\n";
        cout << "Enter a new guess: ";
        cin >> guess;
    }
    cout << "That's correct! Thanks for playing!\n";
    */
    /*#3 Program that figures out user-inputted number 1-100
    int ans, guess;
    int lb = 0;
    int ub = 100;
    int i = 0;
    cout << "Enter a number between 1-100 for me to guess: ";
    cin >> ans;
    if (ans < 1 || ans > 100)
    {
        cout << "You didn't follow directions...";
        exit(0);
    }

    while (guess != ans)
    {
        guess = randRange(lb,ub);
        i++;
        cout << "Guess #" << i << " = " << guess << endl;
        if (guess > ans)
        {
            cout << "That's too high!\n";
            ub = guess;
        }
        else if (guess < ans)
        {
            cout << "That's too low!\n";
            lb = guess;
        }
    }
    cout << "It took me " << i << " attempts, but your number was " << guess << " wasn't it?";
    */
    //#4 Slot machine game
    //Ask for initial payment & allocate to account
    double balance = 0;
    double winnings = 0;
    int a, b, c, pull, au, bu, cu, results;
    int turns = 0;
    cout << "Welcome to Ryan's slot machine game!\n";
    cout << "Each pull of the slot machine costs $1.\n";
    cout << "Enter payment to begin: ";
    cin >> balance;
    cout << "You have " << balance << " chances to go!\n";
    while (balance >= 1)
    {
    //Set winning numbers
        a = randRange(0,9);
        b = randRange(0,9);
        c = randRange(0,9);
    //Ask for user to pull lever
        cout << "Press 1 to pull the lever, and 0 to cash out: ";
        cin >> pull;
        if (pull == 0)
            break;
        else
            balance--;
            turns++;
            cout << "The slots are rolling!!!\n";
            au = randRange(0,9);
            bu = randRange(0,9);
            cu = randRange(0,9);
    //Check to see if random chances match winning numbers
        cout << "Results:\t" << au << "\t" << bu << "\t" << cu << endl;
        cout << "Winners:\t" << a << "\t" << b << "\t" << c << endl;
        results = CompareResults(a,b,c,au,bu,cu);
        //cout << "~*~ Debug ~*~ main_results = " << results << endl;
    //Calculate winnings & add to account
        winnings = CalcWinnings(results);
        //cout << "~*~ Debug ~*~ winnings = " << winnings << endl;
        if (winnings > 0)
            cout << "You won $" << winnings << "!!\n";
        else
            cout << "You didn't win...\n";
        balance = balance + winnings;
        cout << "Your balance is currently: $" << balance << endl;
    }
    cout << "You lasted " << turns << " rounds...\n";
    if (balance < 1)
        cout << "Thanks for all your money!\n";
    else
        cout << "Enjoy your winnings!\n";

}

