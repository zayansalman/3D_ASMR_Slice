# Research and Evaluation

This document summarises the research behind the game and the user study run for the final-year dissertation (Brunel University London, CS3072). It covers **why** the game was built this way, **how** it was evaluated, and **what the results showed**.

Only aggregate results are published here. Individual questionnaire responses are not part of this repository.

---

## 1. Research question

Can an interactive 3D game that borrows the triggers of ASMR and "oddly satisfying" videos help players relax, and would people use it instead of (or alongside) watching videos?

The problem framing came from the COVID-19 period in which the project was written: stress and loneliness were high, and access to in-person therapy was limited. Digitally delivered content such as ASMR and gaming was already widely used for stress relief.

## 2. Literature basis

| Theme | What it contributed to the design |
|-------|-----------------------------------|
| **ASMR** (Barratt & Davis, 2015; Barratt, Spence & Davis, 2017) | Survey evidence that viewers seek ASMR mainly for relaxation, sleep and stress reduction. Triggers are typically tapping, scratching and slow movements. Sound is a primary trigger, so audio was treated as a core feature. |
| **ASMR and physiology** (Poerio, 2018; Lochte, 2018) | Reported reductions in heart rate and activation of brain regions tied to social cognition. Used to justify the stress-relief hypothesis. |
| **Satisfying videos** (Werning, 2020) | The appeal comes from anticipating material interactions and seeing them resolve. This shaped the choice of slicing, deforming and cloth scenarios. |
| **Mirror neuron theory** (Mistry, 2015) | Watching an action can evoke the feeling of doing it. A game lets the player perform the action, so the effect should be stronger than watching. |

**Why slicing was the lead mechanic.** Slicing is among the most-watched satisfying content. The dissertation breaks its appeal into six qualities, and the slicing level was built to hit each one:

1. **Order** — cutting in one direction until the object is fully sliced
2. **Efficiency** — clean slices with no waste
3. **Precision** — the knife cuts exactly where it is placed
4. **Automation** — seamless repetition
5. **Mechanical reaction** — how pieces fall and deform after the cut
6. **Effortlessness** — a sharp knife passing cleanly through

Realism was a design driver because Barratt & Davis found viewers prefer realistic scenes with a close but readable camera. That is why the slicing level uses 4K scanned objects and materials, with camera controls the player can adjust.

## 3. Requirements and process

- **Requirements** were written as a table (requirement, approach, expected result, test). Examples: a reset button, second-finger rotation of the knife, real-time slicing that produces two physical halves (EzySlice), recorded real chopping audio, touch speed that works across devices, and on-screen instructions.
- **Process:** Agile with Scrum-style sprints. Each sprint ended with a working build, which suited a proof of concept where requirements kept changing.
- **Testing during development:** Unity Remote on an iPad Air 4 for touch input, with a hosted WebGL build at the end of each sprint to check both small and large touch screens. Bugs were found by ad-hoc play-testing and logged with reproduction steps.

## 4. The three levels evaluated

| Level | What the player does | Implementation |
|-------|----------------------|----------------|
| **Vegetable slicing** | Move the knife with one finger, rotate it with a second, slice onion and garlic with chopping audio | `Slicer`, `SliceListener`, `TouchControl2`, EzySlice |
| **Stress ball** | Poke and drag a deformable ball that dents and springs back | `CubeSphere`, `MeshDeformer`, `MeshDeformerInput` |
| **Cloth** | Touch a script-generated hanging cloth surface | `Grid` (script-generated plane mesh) |

<p>
  <img src="screenshots/slicing-level.jpg" alt="Vegetable slicing level on iPad" width="49%">
  <img src="screenshots/stress-ball-level.jpg" alt="Stress ball level on iPad" width="49%">
</p>

*Slicing and stress-ball levels running on an iPad via Unity Remote (March 2021).*

## 5. Study design

- **Format:** online questionnaire after playing the game. Participants played a browser-hosted build on their own device.
- **Approval:** ethical approval through Brunel's BREO system. Recruitment was limited to Brunel staff and students, by email to Computer Science undergraduates and staff.
- **Collection window:** one week, closing 18 March 2021.
- **Sample:** 17 responses. The sample skews young and technical (median age 22; one much older participant). Not every question was answered by everyone, so counts below give the number who answered.
- **Analysis:** responses exported to Excel, recoded to numeric variables and analysed in SPSS.
- **What was measured:** headphone use, prior ASMR exposure and habits, self-reported low mood, COVID-19 impact, game performance on the device, play time, difficulty, relaxation, satisfaction, ASMR experienced, favourite level, likelihood of replaying, comparison with videos, long-term and isolation benefit, and a 5-star rating with open comments.

## 6. Results

### Did it relax people?

| Felt more relaxed after playing (n=16) | Count |
|----------------------------------------|-------|
| Significantly | 1 |
| Yes | 6 |
| Slightly | 8 |
| No | 1 |

15 of 16 reported at least slight relaxation, but most of those were "slightly". Play time had a weak-to-moderate positive relationship with relaxation (r ≈ 0.4, n=16, median session 5 minutes).

### Did it feel like ASMR and was it satisfying?

| Question | Results |
|----------|---------|
| Experienced ASMR (n=16) | 1 significantly, 3 yes, 10 slightly, 2 no |
| Found it oddly satisfying (n=16) | 2 significantly, 7 yes, 5 slightly, 2 no |
| Found it satisfying (n=15) | 9 yes, 5 neutral, 1 no |
| Overall rating (n=16) | mean 3.75 / 5, median 4, range 3–5 |
| Would recommend for stress relief (n=16) | 12 yes, 4 no |

### Which level worked?

**Vegetable slicing was the favourite for 13 of 16** participants, stress ball for 3, and cloth for none. Open comments matched this: slicing was praised, while the other two levels were described as having less to do and less sound.

### Compared with watching videos

| Question | Results |
|----------|---------|
| Is a game better than videos? (n=16) | 8 said yes **for slicing**, 6 said yes overall, 2 said no |
| Wished they could interact with videos they watch (n=11) | 9 yes |
| Could help people under isolation (n=16) | 10 yes, 6 no |
| Could reduce stress long term (n=15) | 10 yes, 5 no |

### Would people come back?

Of 16 respondents, 5 said a few times a month, 5 once a month, 1 several times a week, 1 once a day and 2 several times a day. 2 said never. Of the 8 participants who do not watch ASMR/satisfying videos, 6 said they would play at least once a month (1 said never, 1 did not answer). That suggests some appeal beyond existing ASMR viewers.

### Technical problems mattered

Only 9 of 15 said the game loaded and ran smoothly on their device. Several open comments reported bugs, and one said a broken slicing level made them feel more stressed. Difficulty was rated **easy** by 12 of 16 and **perfect** by 4; nobody found it hard.

## 7. Conclusions

- **The aim was partly met.** Most players felt some relaxation, but mostly "slightly". Audio is probably the main driver of ASMR and relaxation, which matches the prior literature and points to sound design as the next investment.
- **Slicing is the strongest concept.** The project should focus on it rather than spreading effort across many mechanics.
- **The audience is narrower than assumed.** Interaction appeals to some ASMR content, not all. The game is best pitched at people who already enjoy satisfying slicing content.
- **Reliability is part of the experience.** For a stress-relief product, a bug is itself a stressor. Cross-device testing has to be a priority.

## 8. Limitations

- Small, self-selected sample (17) of mostly young Brunel students and staff who already knew what ASMR is (16 of 17). The study cannot say whether the game works for people unfamiliar with ASMR.
- Self-reported relaxation with no baseline or physiological measure, and no control group.
- Single short session (median 5 minutes), so long-term effects are opinion, not measurement.
- Bugs and device problems affected some participants' experience and therefore their answers.

## 9. Future work suggested by participants

- Bring the knife to the point of touch rather than moving it relatively
- More sliceable objects, materials and sounds; sound on the stress-ball and cloth levels
- Levels, progression and rewards to encourage return visits
- Larger touch targets, especially the menu button on phones
- New content such as fluids and shattering
- A longer study with a larger and more varied sample

Levels, progression and rewards were later added in the browser port: see the levels, scoring, combos and unlockables in the [README](../README.md).
