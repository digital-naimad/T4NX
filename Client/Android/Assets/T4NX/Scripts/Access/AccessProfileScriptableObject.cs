using System.Collections.Generic;
using UnityEngine;

namespace T4NX
{

    [CreateAssetMenu(fileName = "AccessProfile_", menuName = "Access/Profile", order = 4)]
    public class AccessProfileScriptableObject : ScriptableObject
    {
        [SerializeField] private List<AccessScope> _permissions = new List<AccessScope>();

        /// <summary>
        /// Checks if Profile allows for access to given scope of features
        /// </summary>
        /// <param name="accessScopeToFind"></param>
        /// <returns></returns>
        public bool IsFeatureAvailable(AccessScope accessScopeToFind)
        {
            AccessScope scope = _permissions.Find(accessScope => accessScope == accessScopeToFind);
            return scope == accessScopeToFind;
        }
    }
}
