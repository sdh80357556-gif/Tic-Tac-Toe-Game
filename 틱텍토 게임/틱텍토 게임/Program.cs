using System;

string[] board = new string[9]; 
string player1 = "X"; 
string player2 = "O"; 
string currentPlayer = player1; 
bool gameOver = false; 
int turnCount = 0;
// 게임 작성에있어 어떤 요소부터 만들지 어떤구조를 만들어야하는지 파악한후 메모장에 따로 작성해서 생각하면서 만들어보기 
//모르는게 있으면 본문을 찾아가면서 알게된정보를  주석을 달아 본문을 어디 부분을 참조했는지 알수있도록 공부겸 작성하면서 제작하는게 목표로

for (int i = 0; i < board.Length; i++) //.Length 는 배열의 개수칸 이므로 배열 칸수인 9 만큼 반복하여 "." 를 보드칸을 채워줌. (11. 배열에서 참조)
{
    board[i] = ".";
} while (!gameOver)/* 참조 본문 9. 반복문 랑  7. 연산자 
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
    if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 9)
    //&&는 둘다 맞아야 true이기에 더 정밀하게 검사하게됨  입력한 문자가  Prase는 숫자 아닐경우 종료가돼니 TryParse로 작성함 input으로 입력한 글자가 정수일경우 OUT 내보내내서 int(정수인) choice 에 들어가는 구조임
    {
        int index = choice - 1;
        // 배열은 0부터 시작하기에 -1 를 작성

        if (board[index] == ".") //index 에 currentPlayer 를 담아서 "." 에 O 나 x표시로 변경후 턴횟수 1 경과하도록 작성 
        {
            board[index] = currentPlayer;
            turnCount++;    //턴 횟수를 딱 1만큼 올려줌. 

            // 승리 조건 작성하기  틱텍토 게임 승리조건은 대각선,가로,세로 3개 이어지면 승리하기에 ㅣㅣ 를 활용해 하나라도 달성할경우 승리 하도록 작성할것 (본문 7.연산자와 8. 조건문을 참조함)
            bool win =
                (board[0] == currentPlayer && board[1] == currentPlayer && board[2] == currentPlayer) ||
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
                Console.WriteLine($"플레이어 {currentPlayer} 승리!");
                gameOver = true; //while문 이 반복하지않고 종료하는역할 !의해서 false가됨
            }
            else if (turnCount == 9) // 9턴이지나도 승부가 안날경우 무승부 메세지가 뜨면서 게임이 종료 되도록 작성할것 
            {
                Console.Clear();
                Console.WriteLine("\n무승부입니다!");
                gameOver = true;
            }
            if (currentPlayer == player1) // 처음에는 for (int turnCount = 0; turnCount < 9; turnCount++) 로 for문으로 작성했으나 While 문에도 동일하게 작동해서 통합함
            {
                currentPlayer = player2;
            }
            else
            {
                currentPlayer = player1;
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