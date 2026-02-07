using System;

Random random = new Random();
Console.CursorVisible = false;
int height = Console.WindowHeight - 1;
int width = Console.WindowWidth - 5;
bool shouldExit = false;

// Console position of the player
int playerX = 0;
int playerY = 0;

// Console position of the food
int foodX = 0;
int foodY = 0;

// Available player and food strings
string[] states = { "('-')", "(^-^)", "(X_X)" };
string[] foods = { "@@@@@", "$$$$$", "#####" };

// Current player string displayed in the Console
string player = states[0];

// Index of the current food
int food = 0;

// Speed of player character
int speed = 1;

InitializeGame();
while (!shouldExit)
{
    TerminateOnResize();
    Move();
    ProcessPlayerFoodConsumption();
}

// Returns true if the Terminal was resized 
bool TerminalResized()
{
    return height != Console.WindowHeight - 1 || width != Console.WindowWidth - 5;
}

// Displays random food at a random location
void ShowFood()
{
    // Update food to a random index
    food = random.Next(0, foods.Length);

    // Update food position to a random location
    foodX = random.Next(0, width - player.Length);
    foodY = random.Next(0, height - 1);

    // Display the food at the location
    Console.SetCursorPosition(foodX, foodY);
    Console.Write(foods[food]);
}

// Changes the player to match the food consumed
void ChangePlayer()
{
    player = states[food];
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

// Temporarily stops the player from moving
void FreezePlayer()
{
    System.Threading.Thread.Sleep(1000);
    player = states[0];
}

void Move(bool terminateOnNondirectional = false)
{
    int lastX = playerX;
    int lastY = playerY;

    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.UpArrow: playerY -= speed; break;
        case ConsoleKey.DownArrow: playerY += speed; break;
        case ConsoleKey.LeftArrow: playerX -= speed; break;
        case ConsoleKey.RightArrow: playerX += speed; break;
        case ConsoleKey.Escape: ClearAndTerminate(); return;
        default:
            if (terminateOnNondirectional) ClearAndTerminate();
            return;
    }

    // Clamp to bounds
    playerX = Math.Clamp(playerX, 0, width);
    playerY = Math.Clamp(playerY, 0, height);

    // Clear old position
    Console.SetCursorPosition(lastX, lastY);
    Console.Write(new string(' ', player.Length));

    // Draw at new position
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

// Clears the console, displays the food and player
void InitializeGame()
{
    Console.Clear();
    ShowFood();
    Console.SetCursorPosition(0, 0);
    Console.Write(player);
}

void TerminateOnResize()
{
    if (TerminalResized())
    {
        ClearAndTerminate();
        Console.WriteLine("Console was resized. Program exiting.");
    }
}

void ClearAndTerminate()
{
    Console.Clear();
    shouldExit = true;
}

void ProcessPlayerFoodConsumption()
{
    if (playerX == foodX && playerY == foodY)
    {
        ChangePlayer();
        SetPlayerSpeed();
        ShowFood();
    }
}

void SetPlayerSpeed()
{
    if (player == states[0])
    {
        speed = 1;
    }
    else if (player == states[1])
    {
        speed = 4;
    }
    else if (player == states[2])
    {
        speed = 1;
        FreezePlayer();
    }
    else
    {
        speed = 1;
    }
}