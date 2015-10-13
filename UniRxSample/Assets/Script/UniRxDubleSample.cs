using UniRx;
using UniRx.Triggers;

using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class UniRxDubleSample : MonoBehaviour 
{
    public Button _button;
    public Text _text;

    void Start()
    {
//         _button.onClick
//             .AsObservable()
//             .Subscribe(_ =>
//             {
//                 _text.text = "Wow " + Time.realtimeSinceStartup;
//             });
        var clickStream = this.UpdateAsObservable()
            .Where(_ => Input.GetButtonDown("Fire1"));

        clickStream.Buffer(clickStream.Throttle(System.TimeSpan.FromMilliseconds(200)))
            .Where(x => x.Count >= 2)
            .Subscribe(x =>
            {
                _text.text += "Clicked : " + x.Count + "\n";
            });
    }
}
