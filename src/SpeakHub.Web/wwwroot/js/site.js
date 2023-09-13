// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// app.js
import { tweets } from "./data.js";
const tweetList = document.getElementById("tweetList");

function getTweets() {
    tweets.map((tweet) => {
        tweetList.innerHTML += `<li class="timeline-border py-3 px-4">
    <!-- profile-pic -->
    <figure class="profile-pic">
      <img
        class="rounded-full"
        src="${tweet.profilePicture}"
        alt="user-profil-pic"
      />
    </figure>
    <!-- tweet-area -->
    <div class="ml-3 mt-2 w-full">
      <!-- user-name -->
      <div class="tweet-username">
        <div class="font-bold text-textColor">
          <a href="#">${tweet.name}</a>
        </div>
        <div class="flex text-lightGray">
          <div class="px-1 text-lightGray">
            <a href="#">${tweet.username}</a>
          </div>
          <div>
            <span>·</span>
          </div>
          <div class="px-1">
            <a href="#">${tweet.date}</a>
          </div>
        </div>
      </div>
      <!-- tweet-text -->
      <div class="tweet-text">
        <p>
          ${tweet.text}
        </p>
      </div>
      <!-- tweet-pic -->
      <figure class="pt-3">
        <a href="#">
          <img
            class="max-h-72 w-full object-cover rounded-2xl"
            src="${tweet.image}"
            alt=""
          />
        </a>
      </figure>
      <!-- reaction-icons -->
      <div class="reaction-icons">
        <!-- reply-icon -->
        <a href="#">
          <img
            src="./assets/icons/tweet/reply.svg"
            alt="reply-icon"
          />
        </a>
        <!-- retweet-icon -->
        <a href="#">
          <img
            src="./assets/icons/tweet/retweet.svg"
            alt="retweet-icon"
          />
        </a>
        <!-- like-icon -->
        <a href="#">
          <img src="./assets/icons/tweet/like.svg" alt="like-icon" />
        </a>
        <!-- share-icon -->
        <a href="#">
          <img
            src="./assets/icons/tweet/share.svg"
            alt="share-icon"
          />
        </a>
      </div>
    </div>
  </li>`;
    });
}
getTweets();

//data.js
export const tweets = [
    {
        id: 0,
        profilePicture: "assets/images/user-profil.png",
        name: "Altan Kurt",
        username: "@aaltankurt",
        date: "1h",
        text: "I had gone out to take photos early in the morning, and it was my lucky day!",
        image: "assets/images/tw-pic-2.png",
    },
    {
        id: 1,
        profilePicture: "assets/images/tw-github.png",
        name: "GitHub",
        username: "@github",
        date: "2h",
        text: "How are you protecting your organization from security threats? Join us at #OfficialCyberSummit to learn how GitHub can help.",
        image: "assets/images/tw-pic-1.png",
    },
    {
        id: 2,
        profilePicture: "assets/images/tw-deno.png",
        name: "Deno",
        username: "@deno_land",
        date: "4d",
        text: "Got a question for one of our engineers? Come ask it at our next Office Hours — tomorrow, Friday 9am PT, on our Discord! RVSP -> discord.gg/deno",
        image: "",
    },
];
//navbar.js
// select navigation buttons
const navButtons = document.querySelectorAll(".nav-button");

// reset the properties of the navigation buttons
const resetNavButtons = () => {
    navButtons.forEach((btn) => {
        btn.classList.remove("active");

        btn.style.fontWeight = 400;
        const img = btn.querySelector("img");
        if (img) {
            img.src = img.src.replace("-fill", "");
        }
    });
};

// make the selected button active
const setActiveNavButton = (button) => {
    button.classList.add("active");

    button.style.fontWeight = 700;
    const img = button.querySelector("img");
    if (img) {
        img.src = img.src.replace(".svg", "-fill.svg");
    }
};

// interaction with the buttons
navButtons.forEach((button) => {
    button.addEventListener("click", () => {
        resetNavButtons();
        setActiveNavButton(button);
    });
});
