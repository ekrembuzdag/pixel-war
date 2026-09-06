using UnityEngine;

public class ignis_animation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private Transform ignisVisual;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Player1'in altındaki gerçek Ignis görüntüsünü bul
        ignisVisual = transform.Find("ignisvisual");

        if (ignisVisual != null)
        {
            animator = ignisVisual.GetComponent<Animator>();
        }
    }
    void Update()
    {
        if (rb == null || animator == null || ignisVisual == null)
            return;

        // Saldırı animasyonu oynuyorsa yürüyüş sistemine dokunma
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);

        if (state.IsName("ignis_attack"))
            return;

        float yatayHiz = rb.linearVelocity.x;

        bool yuruyor = Mathf.Abs(yatayHiz) > 0.01f;
        animator.SetBool("she's walking", yuruyor);

        if (yatayHiz < -0.01f)
        {
            Vector3 scale = ignisVisual.localScale;
            scale.x = -Mathf.Abs(scale.x);
            ignisVisual.localScale = scale;
        }
        else if (yatayHiz > 0.01f)
        {
            Vector3 scale = ignisVisual.localScale;
            scale.x = Mathf.Abs(scale.x);
            ignisVisual.localScale = scale;
        }
    }
}