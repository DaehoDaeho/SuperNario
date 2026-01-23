using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    // 싱글톤.
    public static ParticleManager instance = null;

    [SerializeField]
    private GameObject[] particles;

    private void Awake()
    {
        instance = this;
    }

    void OnDestroy()
    {
        instance = null;
    }

    /// <summary>
    /// 파티클 재생 함수.
    /// </summary>
    /// <param name="index">재생할 파티클의 배열 인덱스</param>
    /// <param name="pos">재생할 파티클의 위치</param>
    public void PlayFX(int index, Vector3 pos)
    {
        if(index < 0 || index >= particles.Length)
        {
            return;
        }

        GameObject go = Instantiate(particles[index], pos, Quaternion.identity);
        if(go != null)
        {
            // 파티클의 자식까지 모두 가져오기 위한.
            ParticleSystem[] particle = go.GetComponentsInChildren<ParticleSystem>();
            if(particle != null)
            {
                for(int i=0; i<particle.Length; ++i)
                {
                    particle[i].Play();                    
                }
            }

            // 2초 후 파괴되도록 설정.
            Destroy(go, 2.0f);
        }
    }
}
