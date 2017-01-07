#include <iostream>

using namespace std;

struct PersonalInfo
{
    string name;
    string address;
    string phone_num;
};

struct SpaceShip
{
    int x_position;
    int y_position;
    string name;
};

SpaceShip EnterShipInfo(SpaceShip ss);
void DisplayShipInfo(SpaceShip ss);
SpaceShip moveShips(SpaceShip ss);

int main()
{
    /*#1 Single structure for person to enter info
    PersonalInfo person;
    cout << "Please enter your name: ";
    cin >> person.name;
    cout << "\nPlease enter your address: ";
    cin >> person.address;
    cout << "\nPlease enter your phone number: ";
    cin >> person.phone_num;
    cout << "\n\nYour information is as follows...\n";
    cout << "Name: " << person.name << endl;
    cout << "Address:" << person.address << endl;
    cout << "Phone Number: " << person.phone_num << endl;
    */
    //#2 Create spaceship array that moves off screen
    SpaceShip ships;
    int moves = 0;
    ships = EnterShipInfo(ships);
    /*cout << "Enter the info for the spaceship to move offscreen.\n";
    for (int i = 0; i < 3; i++)
    {
        cout << "\nName Spaceship " << i << ": ";
        cin >> ships[i].name;
        cout << "Enter " << ships[i].name << "'s x position: ";
        cin >> ships[i].x_position;
        cout << "Enter " << ships[i].name << "'s y position: ";
        cin >> ships[i].y_position;
    }
    cout << "Name The Spaceship: ";
    cin >> ships.name;
    cout << "Enter " << ships.name << "'s x position: ";
    cin >> ships.x_position;
    cout << "Enter " << ships.name << "'s y position: ";
    cin >> ships.y_position;*/
    DisplayShipInfo(ships);
    /*for (int i = 0; i < 3; i++)
    {
        cout << "Name: " << ships[i].name << endl;
        cout << "X: " << ships[i].x_position << endl;
        cout << "Y: " << ships[i].y_position << endl;
    }


    cout << "Name: " << ships.name << endl;
    cout << "X: " << ships.x_position << endl;
    cout << "Y: " << ships.y_position << endl;
    */
    while(ships.x_position < 1024 )
    {
        ships = moveShips(ships);
        cout << "All SpaceShips have moved 100 spaces to the right!\n";
        moves++;
        cout << "That's move number " << moves << "!\n";
    }

}

SpaceShip moveShips(SpaceShip ss)
{
    ss.x_position += 100;
    return ss;
}

void DisplayShipInfo(SpaceShip ss)
{
    cout << "Name: " << ss.name << endl;
    cout << "X: " << ss.x_position << endl;
    cout << "Y: " << ss.y_position << endl;

}

SpaceShip EnterShipInfo(SpaceShip ss)
{
    cout << "Enter the info for the spaceship to move offscreen.\n";
    cout << "Enter the spaceship's name: ";
    cin >> ss.name;
    cout << "Enter " << ss.name << "'s x position: ";
    cin >> ss.x_position;
    cout << "Enter " << ss.name << "'s y position: ";
    cin >> ss.y_position;
    return ss;
}

