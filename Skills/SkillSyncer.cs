using Photon;
using Logger = FTKAPI.Utils.Logger;

namespace FTKModTemplate
{
    public class SkillSyncer : PunBehaviour
    {
        public SkillSyncer()
        {
            SkillContainer.Instance.Syncer = this;
            Logger.LogWarning("SkillSyncer created and linked to SkillContainer");
        }

        public void SyncResilient(bool _proc)
        {
            photonView.RPC("SyncResilientRPC", PhotonTargets.All, _proc);
        }

        [PunRPC]
        public void SyncResilientRPC(bool _proc)
        {
            SkillContainer.Instance.resilientAura.proc = _proc;
        }
    }
}
