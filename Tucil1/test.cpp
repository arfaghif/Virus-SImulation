//Nama: Naufal Arfananda Ghifari
//Nim : 13518096
//Kelas: 03
//Hal : Convex Hull
/*
Convex Hull dari himpunan titik S adalah himpunan convex terkecil yang mengandung S.
Untuk dua titik, maka convex hull berupa garis yang menghubungkan 2 titik tersebut. Untuk
tiga titik yang terletak pada satu garis, maka convex hull adalah sebuah garis yang
menghubungkan dua titik terjauh. Sedangkan convex hull untuk tiga titik yang tidak terletak
pada satu garis adalah sebuah segitiga yang menghubungkan ketiga titik tersebut. Untuk titik
yang lebih banyak dan tidak terletak pada satu garis, maka convex hull berupa poligon convex
dengan sisi berupa garis yang menghubungkan beberapa titik pada S. 

*/

//input output
#include <iostream>
//Memakai nilai tak hinnga
#include <limits>
//Pembacaan angka acak
#include <cstdlib>
#include <ctime>
//Penghitungan waktu eksekusi program
#include <chrono> 

using namespace std;
using namespace std::chrono; 

struct point{
    int x;
    int y;
};

const float inf = std::numeric_limits<float>::infinity();
const struct point foo = {-999, -998};


float grad(point P1, point P2);
//Menghasilkan gradien antara titik P1 dan P2

float mins(float m1, float m2);
//Menghasilkan gradien baru m1 yang sudah dirotasi sudutnya dengan m2

float ortho(float m);
//Menghasilkan gradien yang tegak lurus dengan garis m

bool cmpr(point P1, point P2);
//Membandinfkan dua titik P1. P2. Menghasilkan true jika sama

void BacaPoint(point *P);
//Membaca point P

int main(){
    //Membaca jumlah titik divalidasi sehingga N >0
    int N;
    int i;
    int count=0;
    point F, P;
    srand((int)time(0));

    do{
        cout << "Masukkan jumlah titik : ";
        cin >> N;
    }while(N<=0);
    point A[N];
    point B[N];// Array yang berisi kumpulan titik convex hull
    //Membaca random semua titik dan masukkan pada array titik A
    //Titik paling kiri disimpan di F dan dijadikan elemen terakhir array

    auto start1 = high_resolution_clock::now();
    BacaPoint(&F);
    for (i=0; i<N-1; i++){
        BacaPoint(&P);
        if (P.x< F.x or (P.x == F.x and P.y < F.y)){
            A[i] = F;
            F =P;
        }else{
            A[i] = P;
        }
    }
    A[N-1] = F;
    B[0] = F;
    count++;
    auto stop1 = high_resolution_clock::now();

    //Print titik yang terpilih acak
    cout <<"\nTitik yang didapat: \n";
    for (i = 0; i<N; i++){
        cout << "\n(";
        cout << A[i].x;
        cout << ",";
        cout << A[i].y;
        cout << ")\n";
    }
    

    
    auto start2 = high_resolution_clock::now(); 
    //Memulai brute force
    //Cari titik kedua
    float m,mi;
    int index=0;
    while (cmpr(A[index],F) && index <N-1 ){
        A[index] = foo;
        index++;
    }
    P = A[index];
    i = index +1;
    m= grad(F, P);
    for (; i<N-1;i++){
        if (!cmpr(F,  A[i]) && !cmpr(A[i] , foo)){
            mi = grad(F,A[i]);
            if (m==inf){
                if (mi==inf && A[i].y>P.y){
                    P= A[i];
                    index =i;
                }
            }else{
                 if (mi> m || mi == inf || (mi==m && m>0 && A[i].y> P.y)|| (mi==m && m<0 && A[i].y< P.y)||(mi==m && m==0 && A[i].x> P.x)){
                    P = A[i];
                    index =i;
                    m= mi;
                 }
            }
        }else if (cmpr(F,A[i]))
        {
            A[i] =foo;
        }   
    }
    point P0 = F;
    if (!cmpr( P , F)){
        B[1] = P;
        A[index] = foo;
        P0 = P;
        count++;
    }


    //Cari titik-titik selanjutnya
    float m4;
    while(!cmpr(P0 ,F)){
        m4 = ortho(m);
        //cari P
        index =0;
        m=inf;
        do {
            if (cmpr(A[index], foo)){
                index++;
            }else if (cmpr(A[index], P0)){
                A[index] = foo;
                index++;
            }
            else{
                m = mins(grad(P0, A[index]), m4);
                index++;
            }
        }while((cmpr(A[index-1], foo) || cmpr(A[index-1], P0) || m== inf)&& index <N);
        index--;
        P = A[index];
        i = index+1;
        //Cari gradien tertinggi
        for (; i< N;i++){
            if (!cmpr(P0 ,A[i]) && !cmpr(A[i] , foo)){
                mi = mins(grad(P0,A[i]),m4);
                if (mi == inf){
                    if(i != N-1){
                        A[i] = foo;
                    }
                }
                else if(mi> m || mi==m) {
                    if (mi==m ){
                        if((A[index].y>P0.y &&A[i].y>A[index].y) || (A[index].y<P0.y &&A[i].y <A[index].y) || (A[index].y==P0.y && A[index].x> P0.x && A[i].x >A[index].x) || (A[index].y==P0.y && A[index].x< P0.x && A[i].x <A[index].x)){
                            P = A[i];
                            index = i;
                            m = mi;
                        }
                    }
                    else{
                        P = A[i];
                        index = i;
                        m = mi;
                    }
                }
            }else if(cmpr(P0, A[i])){
                A[i] =foo;
            }
        }
        if (!cmpr(P, F)){
            B[count] = P;
            count++;
            m= grad(P,P0);
            A[index] = foo;
        }
        P0 =P;
    }
    auto stop2 = high_resolution_clock::now();
    auto duration = duration_cast<nanoseconds>((stop2 - start2) + (stop1 -start1));
    // Print hasil
    cout <<"\n\nTitik yang merupakan convex hull:\n";
    for (i = 0; i<count; i++){
        cout << "\n(";
        cout << B[i].x;
        cout << ",";
        cout << B[i].y;
        cout << ")\n";
    }
    cout << "Waktu eksekusi: "<< duration.count() << " nanosekon" << endl; 
    return 0;
}

//Implementasi fungsi dan prosedur
float grad(point P1, point P2){
    if (P1.x == P2.x) {
        return inf;
    }else{
        return (((float)(P2.y-P1.y))/((float)(P2.x-P1.x)));
    }
}

float mins(float m1, float m2){
    if (m1==inf and m2==inf){
        return 0;
    }else if(m1==inf){
        if (m2==0){
            return inf;
        }
        else{
            return 1/m2;
        }
    }else if(m2==inf){
        if (m1==0){
            return inf;
        }else{
            return -1/m1;
        }
    }else if (m1*m2<=-0.9999 && m1*m2 >= -1.0001){
        return inf;
    }else{
        return ((m1-m2)/(1+m1*m2));
    }
}

float ortho(float m){
    if (m== inf){
        return 0;
    }else if (m== 0){
        return inf;
    }else{
        return -1/m;
    }
}

bool cmpr(point P1, point P2){
    return (P1.x == P2.x && P1.y ==P2.y);
}

void BacaPoint(point *P){
    (*P).x = (rand() % 200) - 100;
    (*P).y = (rand() % 200) - 100;
}