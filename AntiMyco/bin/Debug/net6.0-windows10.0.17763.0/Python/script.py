import os
from sys import argv

import base64
import xml.etree.cElementTree as ET
from rdkit import Chem
from rdkit.Chem import Draw, AllChem

from mol_validate import MolValidate
import predictor
import similarity


def main():
    smiles = argv[1]
    results = predictor.predict(smiles)

    sim = similarity.calc_similarity(smiles)

    intermed = Chem.MolFromSmiles(smiles)
    AllChem.Compute2DCoords(intermed)

    id = MolValidate.get_unique_id(intermed)
    pic_url = os.getcwd() + '\\Files\\' + id + '.svg'
    Draw.MolToFile(intermed, os.path.join(pic_url), size=(300, 300))
    # pic_base64 = ""
    # with open(pic_url, "rb") as image_file:
    #   pic_base64 = base64.b64encode(image_file.read())

    root = ET.Element("doc")

    # ET.SubElement(doc, "smiles").text = smiles
    ET.SubElement(root, "nr_ahr").text = 'true' if results['NR-AhR'] else 'false'
    ET.SubElement(root, "nr_ar").text = 'true' if results['NR-AR'] else 'false'
    ET.SubElement(root, "nr_ar_lbd").text = 'true' if results['NR-AR-LBD'] else 'false'
    ET.SubElement(root, "nr_aromatase").text = 'true' if results['NR-Aromatase'] else 'false'
    ET.SubElement(root, "nr_er").text = 'true' if results['NR-ER'] else 'false'
    ET.SubElement(root, "nr_er_lbd").text = 'true' if results['NR-ER-LBD'] else 'false'
    ET.SubElement(root, "nr_ppar_gamma").text = 'true' if results['NR-PPAR-gamma'] else 'false'
    ET.SubElement(root, "sr_are").text = 'true' if results['SR-ARE'] else 'false'
    ET.SubElement(root, "sr_atad5").text = 'true' if results['SR-ATAD5'] else 'false'
    ET.SubElement(root, "sr_hse").text = 'true' if results['SR-HSE'] else 'false'
    ET.SubElement(root, "sr_mmp").text = 'true' if results['SR-MMP'] else 'false'
    ET.SubElement(root, "sr_p53").text = 'true' if results['SR-p53'] else 'false'
    ET.SubElement(root, "ld50").text = '%.3f' % results["LD50"]
    ET.SubElement(root, "similarity").text = '%.3f' % (sim * 100.0)
    ET.SubElement(root, "pic").text = pic_url

    tree = ET.ElementTree(root)

    tree.write(os.getcwd() + "\\Files\\response.xml")

    import sys
    sys.exit()


if __name__ == '__main__':
    main()
