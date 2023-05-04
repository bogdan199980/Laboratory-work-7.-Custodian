class Program
{
    static void Main(string[] args)
    {
        Hero hero = new Hero();
        hero.Shoot(); 
        GameHistory game = new GameHistory();

        game.History.Push(hero.SaveState()); 

        hero.Shoot(); 

        hero.RestoreState(game.History.Pop());

        hero.Shoot(); 

        Console.Read();
    }
}

// Originator
class Hero
{
    private int patrons = 10; 
    private int lives = 5; 

    public void Shoot()
    {
        if (patrons > 0)
        {
            patrons--;
            Console.WriteLine("Проводимо постріл. Залишилось {0} патронів", patrons);
        }
        else
            Console.WriteLine("Патронів більше немає");
    }
    // сохранение состояния
    public HeroMemento SaveState()
    {
        Console.WriteLine("Збереження гри. Параметри: {0} патронів, {1} життів", patrons, lives);
        return new HeroMemento(patrons, lives);
    }

    // восстановление состояния
    public void RestoreState(HeroMemento memento)
    {
        this.patrons = memento.Patrons;
        this.lives = memento.Lives;
        Console.WriteLine("Відновлення гри. Параметри: {0} патронів, {1} життів", patrons, lives);
    }
}
// Memento
class HeroMemento
{
    public int Patrons { get; private set; }
    public int Lives { get; private set; }

    public HeroMemento(int patrons, int lives)
    {
        this.Patrons = patrons;
        this.Lives = lives;
    }
}

// Caretaker
class GameHistory
{
    public Stack<HeroMemento> History { get; private set; }
    public GameHistory()
    {
        History = new Stack<HeroMemento>();
    }
}