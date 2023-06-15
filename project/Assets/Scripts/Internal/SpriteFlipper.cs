using System.Collections;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    // Определяем переменную для хранения ссылки на компонент SpriteRenderer
    private SpriteRenderer spriteRenderer;

    // Определяем переменные для хранения начального значения масштаба спрайта
    private Vector3 initialScale;

    // Определяем переменную для хранения текущего значения масштаба спрайта
    private Vector3 currentScale;

    // Определяем переменную для хранения начальной ориентации спрайта
    private Quaternion initialRotation;

    // Определяем переменную для хранения текущей ориентации спрайта
    private Quaternion currentRotation;

    // Определяем переменную для определения, перевернут ли спрайт в данный момент
    public bool flipped = false;

    // Определяем переменную для хранения скорости анимации
    public float animationSpeed = 2f;

    private Vector2 currentPoz;

    // Вызывается при запуске игры
    void Start()
    {
        currentPoz      = transform.position;
        // Получаем ссылку на компонент SpriteRenderer
        spriteRenderer  = GetComponent<SpriteRenderer>();

        // Получаем начальное значение масштаба спрайта
        initialScale    = transform.localScale;

        // Получаем начальную ориентацию спрайта
        initialRotation = transform.rotation;
    }

    public void Flip()
    {
        // Если спрайт не перевернут
        if (!flipped)
        {
            // Устанавливаем флаг переворота спрайта
            flipped = true;

            // Запускаем анимацию изменения масштаба спрайта и его переворота
            StartCoroutine(AnimateSpriteFlip(initialScale, new Vector3(-initialScale.x, initialScale.y, initialScale.z), initialRotation, Quaternion.Euler(0f, 180f, 0f)));
        }
        // Если спрайт уже перевернут
        else
        {
            // Устанавливаем флаг переворота спрайта
            flipped = false;

            // Запускаем анимацию изменения масштаба спрайта и его переворота
            StartCoroutine(AnimateSpriteFlip(new Vector3(-initialScale.x, initialScale.y, initialScale.z), initialScale, Quaternion.Euler(0f, 180f, 0f), initialRotation));
        }
    }

    // Метод для запуска анимации изменения масштаба спрайта и его переворота
    private IEnumerator AnimateSpriteFlip(Vector3 startScale, Vector3 endScale, Quaternion startRotation, Quaternion endRotation)
    {
        // Устанавливаем текущее значение масштаба спрайта и его ориентацию в начальные значения
        currentScale    = startScale;
        currentRotation = startRotation;

        // Вычисляем время анимации на основе скорости анимации
        float animationTime = 1f / animationSpeed;

        // Вычисляем, на сколько нужно изменить масштаб и ориентацию спрайта на каждый кадр анимации
        Vector3 scaleIncrement = (endScale - startScale) / animationTime;
        Quaternion rotationIncrement = Quaternion.Slerp(startRotation, endRotation, 1f / animationTime * Time.deltaTime);

        // Запускаем анимацию изменения масштаба и ориентации спрайта
        for (float t = 0f; t < animationTime; t += Time.deltaTime)
        {
            // Изменяем масштаб и ориентацию спрайта на каждый кадр анимации
            currentScale += scaleIncrement * Time.deltaTime;
            currentRotation = Quaternion.Slerp(currentRotation, rotationIncrement, Time.deltaTime * animationSpeed);

            // Применяем изменения к спрайту
            transform.localScale    = currentScale;
            transform.rotation      = currentRotation;

            // Ждем до следующего кадра анимации
            yield return null;
        }

        // Устанавливаем конечные значения масштаба и ориентации спрайта
        transform.localScale = endScale;
        transform.rotation = endRotation;
    }
}
