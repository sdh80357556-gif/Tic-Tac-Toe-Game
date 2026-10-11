using System;

string[] board = new string[9]; 
string player1 = "X";
string player2 = "O";
string currentPlayer = player1;

bool gameOver = false;
int turnCount = 0;



for (int i = 0; i < board.Length; i++) //.Length 는 배열의 개수칸 이므로 배열 칸수인 9 만큼 반복하여 "." 를 보드칸을 채워줌. (11. 배열에서 참조)
{
    board[i] = ".";
}

while (!gameOver)
/* 참조 본문 9. 반복문 랑  7. 연산자 
for문이아니라 왜 while문을 활용했는지는 for문은 명확하게 정해져있을떄 사용하고 While문은 몇번을 반복해야하는지 횟수를 모를때 사용함므로 
while문을 활용하였고 While 문은 true때 사용가능하므로 ! 을 활용하여  false 값을 true로 변경 하였음.*/


{
    Console.Clear();
    Console.WriteLine("=== 틱택토 게임 - 1단계 ===");
    Console.WriteLine("두 사람이 X와 O를 번갈아 놓습니다. X가 먼저 시작합니다.\n");

    Console.WriteLine("위치 번호:");
    Console.WriteLine("1 | 2 | 3 ");
    Console.WriteLine("----------");
    Console.WriteLine("4 | 5 | 6 ");
    Console.WriteLine("----------");
    Console.WriteLine("7 | 8 | 9\n");

    Console.WriteLine("현재 보드:");
    Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
    Console.WriteLine("----------");
    Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
    Console.WriteLine("----------");
    Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}\n");

    Console.WriteLine($"플레이어 {currentPlayer}의 차례입니다.");
    Console.WriteLine("위치를 선택하세요 (1~9):");

    string input = Console.ReadLine();

    //입력받는 숫자가  1~9 사이인지 검사  사용자가 입력한 숫자를 bool로 알려주도록 하며 실패해도 멈추지않게 하고 성공하면 정수가  choice에 담도록 작성할것 (본문 6 .사용자 입력 7. 연산자 참조함) 
    if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 9) //&&는 둘다 맞아야 true이기에 더 정밀하게 검사하게됨
    {
        int index = choice - 1; // 배열은 0부터 시작하기에 -1 를 작성

        if (board[index] == ".") //index 에 currentPlayer 를 담아서 "." 에 x표시로 변경후 턴횟수 1 경과하도록 작성 
        {
            board[index] = currentPlayer;
            turnCount++;    //턴 횟수를 딱 1만큼 올려줌. 

            // 승리 조건 작성하기 가로,세로,대각선 이 3칸이 이어질경우 승리 이므로 ||을 활용하여 한줄이라도 이어질경우 승리 할수있도록 만들어야함 (본문 7. 연산자와 8. 조건문을 참조함) 
            bool win =                                    
                (board[0] == currentPlayer && board[2] == currentPlayer && board[3] == currentPlayer) ||
                (board[3] == currentPlayer && board[4] == currentPlayer && board[5] == currentPlayer) ||
                (board[6] == currentPlayer && board[7] == currentPlayer && board[8] == currentPlayer) ||
                (board[0] == currentPlayer && board[3] == currentPlayer && board[6] == currentPlayer) ||
                (board[1] == currentPlayer && board[4] == currentPlayer && board[7] == currentPlayer) ||
                (board[2] == currentPlayer && board[5] == currentPlayer && board[8] == currentPlayer) ||
                (board[0] == currentPlayer && board[4] == currentPlayer && board[8] == currentPlayer) ||
                (board[2] == currentPlayer && board[4] == currentPlayer && board[6] == currentPlayer);
            
            if (win)
            {
                Console.Clear();
                Console.WriteLine("=== 틱택토 게임 - 1단계 ===");
                Console.WriteLine("현재 보드");
                Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
                Console.WriteLine("----------");
                Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
                Console.WriteLine("----------");
                Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}\n");
                Console.WriteLine($"플레이어 {player1} 승리!");
                gameOver = true; // while문이 더이상 돌지않도록 
            }
            else if (turnCount == 9) // 만약 9턴 동안 승부가 안날경우 무승부를 띄우며  게임 종료 하도록 작성할것
            {
                Console.Clear();
                Console.WriteLine("\n무승부입니다!");
                gameOver = true;
            }
            else // 플레이어가 차례를 번갈아며 숫자를 입력하여  그 숫자칸에 O,X가 나오도록 작성
            {
                if (currentPlayer == player1)
                {
                    currentPlayer = player2;
                }
                else
                {
                    currentPlayer = player1;
                }
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
