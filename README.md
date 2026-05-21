# 🚀 Galactic Shooter 2D - Unity WebGL Project

> **Galactic Shooter 2D**, Unity Oyun Motoru kullanılarak geliştirilmiş 2D arcade uzay savaş oyunudur. Oyuncu, düşman gemilerini yok ederek mümkün olduğunca yüksek skor elde etmeye çalışır.

🎮 **Tarayıcıda Oyna (WebGL):**  
:contentReference[oaicite:0]{index=0}

---

## 📸 Oyun İçi Görseller

<img width="1280" height="720" alt="Gameplay Screenshot" src="https://github.com/user-attachments/assets/YOUR_SCREENSHOT_ID" />

---

## 🕹️ Oynanış Mekanikleri

Oyuncu uzay gemisini kontrol ederek gelen düşmanları yok etmeye çalışır. Oyun ilerledikçe skor artar ve ekrandaki düşman yoğunluğu artabilir.

### 🎯 Temel Özellikler

- 🚀 2D uzay savaş mekaniği
- 👾 Sürekli düşman spawn sistemi
- 💥 Patlama efektleri
- 🔫 Lazer ateş sistemi
- 🛡️ Güçlendirme (Power-Up) sistemi
- 📈 Skor sistemi
- 🎵 Ses efektleri ve oyun içi ses yönetimi
- 🌌 Uzay temalı arkaplan ve görseller

---

## ⚡ Power-Up Sistemi

Oyun içerisinde oyuncuya yardımcı olan çeşitli bonuslar bulunmaktadır.

| Bonus Türü | Etki |
| :--- | :--- |
| **Shield Bonus** | Geçici koruma sağlar |
| **Speed Bonus** | Geminin hareket hızını artırır |
| **Triple Laser** | Aynı anda 3 lazer ateşler |
| **Triple Shot Bonus** | Ateş gücünü artırır |

---

## 🎮 Kontroller

| Tuş | İşlev |
| :--- | :--- |
| `W / ↑` | Yukarı hareket |
| `S / ↓` | Aşağı hareket |
| `A / ←` | Sol hareket |
| `D / →` | Sağ hareket |
| `Space` | Ateş et |

---

## 🧱 Proje Yapısı

Projede temel olarak aşağıdaki sistemler bulunmaktadır:

```text
Scripts/
├── Player_sc.cs
├── Enemy_sc.cs
├── Laser_sc.cs
├── SpawnManager_sc.cs
├── GameManager_sc.cs
├── UIManager_sc.cs
├── Explosion_sc.cs
└── Bonus_sc.cs
```

### 📌 Sistem Açıklamaları

| Script | Görev |
| :--- | :--- |
| `Player_sc.cs` | Oyuncu kontrolü ve hareket sistemi |
| `Enemy_sc.cs` | Düşman davranışları |
| `Laser_sc.cs` | Lazer hareketi ve çarpışmalar |
| `SpawnManager_sc.cs` | Düşman ve bonus üretimi |
| `GameManager_sc.cs` | Oyun akışı ve skor yönetimi |
| `UIManager_sc.cs` | UI ve skor ekranı |
| `Explosion_sc.cs` | Patlama efektleri |
| `Bonus_sc.cs` | Güçlendirme sistemleri |

---

## 🌐 WebGL Desteği

Proje Unity WebGL build sistemi kullanılarak tarayıcı üzerinden oynanabilir hale getirilmiştir.

### 🔧 Kullanılan Teknolojiler

- Unity 6
- C#
- Unity WebGL
- itch.io Deployment

---

## 🛠️ Kurulum ve Test

Projeyi Unity Editör üzerinde çalıştırmak için:

1. Projeyi klonlayın:
```bash
git clone https://github.com/elifnurbeycan/Galactic-Shooter-2D.git
```

2. Unity Hub üzerinden projeyi açın.

3. `Scenes/SampleScene` sahnesini açın.

4. Play tuşuna basarak oyunu çalıştırın.

---

## 📦 Build Alma

WebGL build almak için:

```text
File > Build Profiles > Web > Build
```

---

## 👩‍💻 Geliştirici

**Elif Nur Beycan**  
Bilgisayar Mühendisliği - Oyun Programlama Projesi
