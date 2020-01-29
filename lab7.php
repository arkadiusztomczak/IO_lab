<?php
    $tab = [[1,2,3],[4,5,6],[7,8,9]];
    $maxVal = -1;
    $dims = -1;
    foreach($tab as $tO){
        $dC = 0;
        foreach($tO as $tI){
            if($tI > $maxVal) $maxVal = $tI;
            $dC++;
        }
        $dims = $dC;
    }

    $f = fopen("pgm.pgm", "w");
    
    fwrite($f,"P2\n".$dims." ".$dims."\n".$maxVal."\n");
    foreach($tab as $tO){
        foreach($tO as $tI){
            fwrite($f,$tI." ");
        }
        fwrite($f,"\n");
    }

/*
float * tmp = (float*) malloc (sizeof(float)*w*h);
for(int n=0; n<iter; n++){
for(int y=0; y<h; y++{
for(int x=0; x<w; x++){
int index = y*w+x;
tmp[index] = hx[4]*img[index];
if(x>0) tmp[index]+=hx[3]*img[index-1];
}
img=tmp;
}
}
*/
?>
