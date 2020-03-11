#python 3
def grad(P1,P2):
  if (P1[0]==P2[0]):
    return None
  else:
    return (P1[1] - P2[1])/ (P1[0]-P2[0])
    
def mins(m1,m2):
  if (m1==None and m2 ==None):
    return 0
  elif(m1==None):
    if m2 == 0:
      return None
    else:
      return 1/m2 
  elif (m2==None):
    if m1 == 0:
      return None
    else:
      return -1/m1 
  elif (m1*m2==-1):
    return None
  else:
    return (m2-m1/(1+m1*m2))


A = [] #Array titik titik yang belum di proses
B = [] #Array titik titik hasil
P = [] #titik
F = [] #titik paling kiri pertama


N = int(input("Masukan jumlah titik\n"))
x = int(input())
F.append(x)
y= int(input())
F.append(y)

for i in range (N-1):
  P = []
  x = int(input())
  P.append(x)
  y= int(input())
  P.append(y)
  if (P[0]< F[0] or (P[0] == F[0] and P[1] < F[1])):
    A.append(F)
    F = P
  else:
    A.append(P)

print("Debug 1")    
print(A)
print(B)
print(F)

#Prosesan yang pertama
m= grad(F, A[0])
P = A[0]
index =0
for i in range(1, len(A)):
  mi = grad(F,A[i])
  if (m == None) :
    if (mi==None):
      if (A[i][1] > P[1]):
        P = A[i]
        index = i
  else:
    if (mi> m or mi == None or (mi==m and A[i][1]> P[1])):
      P = A[i]
      index = i
      m = mi
del A[index]
A.append(F)
B.append(P)
P0 = P

print("Debug 2")    
print(A)
print(B)
print(F)
print(P0)


while (P0 !=  F):
  #tegak lurus
  if (m==None):
    m4 = 0
  else:
    m4 = -1/ m
  #anggap yang prtama tertinggi. validasi gaada yg tegak lurus
  m = mins(grad(P0,A[0]),m4)
  while (m == None and len(A) > 1):
    del A[0]
    m = mins(grad (P0, A[0]), m4)
  
  #cari gradien tertinggi
  index =0
  P= A[0]
  for i in range (1, len(A)):
    mi = mins(grad (P0,A[i]),m4) 
    if (mi==None ):
      if (i != len(A)-1):
        del(A[i])
    elif (mi> m or ((mi==m and m>0 and A[i][1]> P[1]) or(mi ==m and m<0 and A[i][1]<P[1]) )):
      P = A[i]
      index = i
      m = mi
  
  B.append(P)
  m = grad(P,P0)
  del A[index]
  P0 = P

  print("tets")
  print(A)
  print(B)


print("Hasil akhir \n")
print(B)