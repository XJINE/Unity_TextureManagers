using UnityEngine;

public class SampleObject : MonoBehaviour
{
    #region Field

    protected float   moveSpeed;
    protected float   animSpeed;
    protected Vector3 target;

    #endregion Field

    #region Method

    protected virtual void Awake()
    {
        this.moveSpeed = Random.Range(1f, 5f);
        this.animSpeed = Random.Range(0f, 1f);

        UpdateTarget();

        Destroy(base.gameObject, Random.Range(3f, 15f));
    }

    protected virtual void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                 target,
                                                 moveSpeed * Time.deltaTime);

        transform.Rotate(animSpeed, animSpeed, animSpeed);

        if (transform.position == target)
        {
            UpdateTarget();
        }
    }

    private void UpdateTarget()
    {
        target = Random.onUnitSphere * 5;
    }

    #endregion Method
}