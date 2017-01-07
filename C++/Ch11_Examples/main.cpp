#include <iostream>

using namespace std;

struct PlayerInfo
{
    int skill_level;
    string name;
};

int main()
{
    PlayerInfo players[5];
    for (int i = 0; i < 5; i++)
    {
        cout << "Please enter the name for player " << i << ": ";
        cin >> players[i].name;
        cout << "Please enter " << players[i].name << "'s skill level: ";
        cin >> players[i].skill_level;
    }
    for (int i = 0; i < 5; i++)
    {
        cout << players[i].name << " is at skill level " << players[i].skill_level << endl;
    }
}
