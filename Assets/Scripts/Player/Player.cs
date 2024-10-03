using UnityEngine;
using DG.Tweening;

public class Player : Entity
{
    [SerializeField] private Ease easeType;
    [SerializeField] private float delay;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float speedIncrement = 0.1f;
    [SerializeField] private float incrementInterval = 5f;
    [SerializeField] private float[] xPositionLanes;

    private bool isAlive = true;
    private int currentLaneIndex = 1;
    private float timeSinceLastIncrement = 0f;
    private ScoreCounter scoreCounter;
    public GameManager gameManager;

    protected override void Start()
    {
        base.Start();
        scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    void Update()
    {
        if (!isAlive) return;

        timeSinceLastIncrement += Time.deltaTime;
        if (timeSinceLastIncrement >= incrementInterval)
        {
            currentSpeed += speedIncrement;
            timeSinceLastIncrement = 0f;
        }

        HandleInput();
        MoveForward();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.A) && currentLaneIndex > 0)
        {
            currentLaneIndex--;
            MovePlayer();
        }
        if (Input.GetKeyDown(KeyCode.D) && currentLaneIndex < xPositionLanes.Length - 1)
        {
            currentLaneIndex++;
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        Vector3 newPosition = new Vector3(xPositionLanes[currentLaneIndex], transform.position.y, transform.position.z);
        transform.DOLocalMove(newPosition, delay).SetEase(easeType);
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }

    protected override void Die()
    {
        isAlive = false;
        scoreCounter?.StopCounting();
        gameManager?.ShowRestartButton();
    }

    public bool IsAlive() => isAlive;
}
