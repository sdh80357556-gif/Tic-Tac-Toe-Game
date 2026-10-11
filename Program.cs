using System;
using System.Xml.Serialization;

string[] board = { ".", ".",  ".",  ".",  ".",  ".",  ".",  ".",  "." };
string player = "X";
bool gameOver = false;
int turnCount = 0;

while (!gameOver)
{
    Console.Clear();
    Console.WriteLine("=== 틱택토 게임 - 1단계 ===");
    Console.WriteLine("두 사람이 x와 O를 번갈아 놓습니다. x가 먼저 시작합니다.\n");

    Console.WriteLine("위치 번호:");
    Console.WriteLine("1 | 2 | 3 ");
    Console.WriteLine("----------");
    Console.WriteLine("4 | 5 | 6 ");
    Console.WriteLine("----------");
    Console.WriteLine("7 | 8 | 9\n");

    Console.WriteLine("현재 보드:");
    Console.WriteLine($"{board[0]} | {board[1]} |{board[2]}");
    Console.WriteLine("----------");
    Console.WriteLine($"{board[3]} | {board[4]} |{board[5]}");
    Console.WriteLine("----------");
    Console.WriteLine($"{board[6]} | {board[7]} |{board[8]}\n");

    Console.WriteLine($"플레이어 {player}의 차례입니다.");
    Console.Write("위치를 선택하세요 (1~9): ");

    string input = Console.ReadLine();

    if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 9)
    {
        int index = choice - 1;

        if (board[index] == ".")
        {
            board[index] = player;
            turnCount++;

            bool win =
                (board[0] == player && board[1] == player && board[2] == player) ||
                  (board[3] == player && board[4] == player && board[5] == player) ||
                  (board[6] == player && board[7] == player && board[8] == player) ||
                  (board[0] == player && board[3] == player && board[6] == player) ||
                  (board[1] == player && board[4] == player && board[7] == player) ||
                  (board[2] == player && board[5] == player && board[8] == player) ||
                  (board[0] == player && board[4] == player && board[8] == player) ||
                  (board[2] == player && board[4] == player && board[6] == player);

            if (win)
            {
                Console.Clear();
                Console.WriteLine("=== 틱택토 게임 - 1단계 ===");
                Console.WriteLine("현재 보드:");
                Console.WriteLine($"{board[0]} | {board[1]} |{board[2]}");
                Console.WriteLine("----------");
                Console.WriteLine($"{board[3]} | {board[4]} |{board[5]}");
                Console.WriteLine("----------");
                Console.WriteLine($"{board[6]} | {board[7]} |{board[8]}\n");
                Console.WriteLine($"플레이어 {player} 승리!");
                gameOver = true;
            }
            else if (turnCount == 9)
            {
                Console.Clear();
                Console.WriteLine("\n무승부입니다!");
                gameOver = true;
            }
            else 
            {
                player = player == "X" ? "O" : "X";
            }
            }
        else
        {
            Console.WriteLine("이미 사용한 칸입니다. 확인 위해 Enter를 누르세요");
            Console.ReadLine();
        }
        }
    else
    {
        Console.WriteLine("잘못된 입력입니다. 1부터 9까지의 숫자를 입력하세요. Enter를 누르세요.");
        Console.ReadLine();
    }
    
}
