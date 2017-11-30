using PlanetStamp;

public class PlanetDTO
{
	private PlanetVO m_vo;

	public string PrefabPath { get { return m_vo.PrefabPath; } }

	public void SetVO(PlanetVO vo)
	{
		m_vo = vo;
	}
}
