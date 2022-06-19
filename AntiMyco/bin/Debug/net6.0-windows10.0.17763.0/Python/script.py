import os
from sys import argv

import base64
import xml.etree.cElementTree as ET
from rdkit import Chem
from rdkit.Chem import Draw, AllChem, Crippen

from mol_validate import MolValidate
import predictor
import similarity


def main():
    smiles = argv[1]
    results = predictor.predict(smiles)

    logp = Crippen.MolLogP(Chem.MolFromSmiles(smiles))

    sim = similarity.calc_similarity(smiles)

    intermed = Chem.MolFromSmiles(smiles)
    AllChem.Compute2DCoords(intermed)

    id = MolValidate.get_unique_id(intermed)
    pic_url = os.getcwd() + '\\Files\\' + id + '.svg'
    Draw.MolToFile(intermed, os.path.join(pic_url), size=(300, 300))

    root = ET.Element("doc")

    ET.SubElement(root, "nr_ahr").text = 'Связан' if results['NR-AhR'] else 'Отсутствует'
    ET.SubElement(root, "nr_ar").text = 'Связан' if results['NR-AR'] else 'Отсутствует'
    ET.SubElement(root, "nr_ar_lbd").text = 'Связан' if results['NR-AR-LBD'] else 'Отсутствует'
    ET.SubElement(root, "nr_aromatase").text = 'Связан' if results['NR-Aromatase'] else 'Отсутствует'
    ET.SubElement(root, "nr_er").text = 'Связан' if results['NR-ER'] else 'Отсутствует'
    ET.SubElement(root, "nr_er_lbd").text = 'Связан' if results['NR-ER-LBD'] else 'Отсутствует'
    ET.SubElement(root, "nr_ppar_gamma").text = 'Связан' if results['NR-PPAR-gamma'] else 'Отсутствует'
    ET.SubElement(root, "sr_are").text = 'Связан' if results['SR-ARE'] else 'Отсутствует'
    ET.SubElement(root, "sr_atad5").text = 'Связан' if results['SR-ATAD5'] else 'Отсутствует'
    ET.SubElement(root, "sr_hse").text = 'Связан' if results['SR-HSE'] else 'Отсутствует'
    ET.SubElement(root, "sr_mmp").text = 'Связан' if results['SR-MMP'] else 'Отсутствует'
    ET.SubElement(root, "sr_p53").text = 'Связан' if results['SR-p53'] else 'Отсутствует'
    ET.SubElement(root, "ld50").text = '%.3f' % results["LD50"]
    ET.SubElement(root, "similarity").text = '%.3f' % (sim * 100.0)
    ET.SubElement(root, "log_p").text = '%.3f' % logp
    ET.SubElement(root, "pic").text = pic_url

    tree = ET.ElementTree(root)

    tree.write(os.getcwd() + "\\Files\\response.xml")

    import sys
    sys.exit()


if __name__ == '__main__':
    main()
