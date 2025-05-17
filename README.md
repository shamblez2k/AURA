# AURA (Augmented User Retail Assistant)

This Unity-based **mobile AR application** enables users to scan
**QR codes next to clothing items** in a store and receive rich,
contextual information such as **styling videos**, **similar
product recommendations**, or **AI-generated descriptions**.

---

## 🎯 Features

- QR Code recognition using phone camera
- AR popup overlay UI anchored to real-world position
- Dynamic content display based on scanned item:
- 📹 YouTube styling video
- 🛒 List of similar items with prices
- 🤖 AI-generated insights (Google Gemini)
- Works on Android phones with ARCore support

---

## 🛠 Tech Stack

- Unity 2021.3.45f1(LTS)
- AR Foundation 4.2.10
- ARCore XR Plugin
- ZXing.Net
- LightWebview
- Unity Canvas-based UI

---

## 📱 Platform Setup – Android

### ✅ Requirements

- ARCore-supported Android device
- Android SDK + USB Debugging enabled

### 🔧 Unity Configuration

1. Switch platform to **Android** in Build Settings
2. Set minimum API level to **29 or higher**
3. Enable **ARCore** in XR Plugin Management
4. Add camera and internet permissions (if using APIs)
5. Connect device → **Build & Run**

---

## 🧪 How It Works

- User points the phone camera at a **generated QR code** (Currently working QR codes are provided in the **QR Codes** directory)
- QR code is scanned using ZXing
- Upon detection:
- A popup UI is displayed showing:
- A play button, which the user can tap to show a YouTube video tutorial related to the clothing item.

#### Coming soon:

- A scrollable list of similar clothing items with prices
- A real-time AI-generated text (via web API)
- Users can interact with the popup for further info or navigation

---

## 📷 Screenshots / Demo

📸 Screenshots coming soon

## 🎥[AURA v0.1 preview](https://www.youtube.com/shorts/yjQlkPmqwQE)

## 🧪 Known Issues

- QR code recognition may struggle in low lighting
- Internet access is required for API or video playback
- Some older Android devices may have limited ARCore support

---

## 👤 Author

- **Name:** Shalif Shaoul
- **LinkedIn:** https://www.linkedin.com/in/sshaoul/

---

## Purpose

**Next Generation Augmented Reality Mobile Apps**

**Fellow:** Milad Mazi

## 📜 License

MIT License
