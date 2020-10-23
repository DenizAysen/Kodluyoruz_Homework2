

public class PlayerModel 
{
    int _score;

    public int GetScore()
    {
        return _score;
    }

    public void ChangeScore(int score)
    {
        _score += score;
    }

}
