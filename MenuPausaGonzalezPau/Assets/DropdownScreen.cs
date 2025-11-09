using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DropdownScreen : MonoBehaviour
{
    Resolution[] resolucionsDisponibles;
    public TMPro.TMP_Dropdown dropdownResolucions;
    List<Resolution> resolucionsFiltrades;
    FullScreenMode fullScreenMode;

    private void Awake()
    {
        resolucionsDisponibles = Screen.resolutions;
    }
    private void Start()
    {
     resolucionsFiltrades = resolucionsDisponibles
    .GroupBy(r => new { r.width, r.height }) 
    .Select(g => g.OrderByDescending(r => r.refreshRateRatio).First()) 
    .ToList();
    OmpleDropdown();
    }
    void OmpleDropdown()
    {
        dropdownResolucions.ClearOptions();
        List<string> opcions = new List<string>();

        foreach (Resolution res in resolucionsFiltrades)
        {
            opcions.Add(res.width + " x " + res.height + " @ " + res.refreshRateRatio + "Hz");
        }

        dropdownResolucions.AddOptions(opcions);
    }
    public void CanviaResolucio(int index)
    {
        Resolution seleccionada = resolucionsFiltrades[index];
        Screen.SetResolution(seleccionada.width, seleccionada.height, fullScreenMode, seleccionada.refreshRateRatio);
    }
}
