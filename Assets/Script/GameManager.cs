using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AIGirl aiGirl;
    void Start()
    {
        aiGirl = Instantiate(aiGirl);
        aiGirl = GetComponent<AIGirl>();

        aiGirl.OptionAIHandler(Moodtype.Happy, 15550);
        Debug.Log("Happy: " + aiGirl.Happy);
    }
}
